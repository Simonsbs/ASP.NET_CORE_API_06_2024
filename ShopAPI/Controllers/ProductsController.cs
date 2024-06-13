﻿using System.Collections;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;

namespace ShopAPI.Controllers;

[ApiController]
[Route("api/categories/{categoryID}/products")]
public class ProductsController : ControllerBase {
	[HttpGet]
	public ActionResult<IEnumerable<ProductDTO>> GetProducts(int categoryID) {
		var products = MyDataStore.Current.Categories
			.FirstOrDefault(c => c.ID == categoryID)?
			.Products;

		if (products == null) {
			return NotFound();
		}

		return Ok(products);
	}

	[HttpGet("{productID}", Name = "GetSingleProduct")]
	public ActionResult<ProductDTO> GetProduct(int categoryID, int productID) {
		var product = MyDataStore.Current.Categories
			.FirstOrDefault(c => c.ID == categoryID)?
			.Products
			.FirstOrDefault(p => p.ID == productID);

		if (product == null) {
			return NotFound();
		}

		return Ok(product);
	}

	[HttpPost]
	public ActionResult CreateProduct(
		int categoryID,
		ProductForCreationDTO productToCreate) {

		var category = MyDataStore.Current.Categories
			.FirstOrDefault(c => c.ID == categoryID);

		if (category == null) {
			return NotFound();
		}

		var maxProductID = MyDataStore.Current.Categories
			.SelectMany(c => c.Products)
			.Max(p => p.ID);

		ProductDTO productDTO = new() {
			ID = maxProductID + 1,
			Name = productToCreate.Name,
			Description = productToCreate.Description
		};

		category.Products.Add(productDTO);

		return CreatedAtRoute(
				"GetSingleProduct",
				new {
					categoryID,
					productID = productDTO.ID,
				},
				productDTO
			);
	}

	[HttpPut("{productID}")]
	public ActionResult UpdateProduct(int categoryID, int productID, ProductForUpdateDTO updatedProduct) {
		var category = MyDataStore.Current.Categories.FirstOrDefault(c => c.ID == categoryID);
		if (category == null) {
			return NotFound("Category not found inorder to update the product");
		}

		var product = category.Products.FirstOrDefault(p => p.ID == productID);
		if (product == null) {
			return NotFound("Product not found");
		}

		product.Name = updatedProduct.Name;
		product.Description = updatedProduct.Description;

		//return Ok(product);
		return NoContent();
	}

	[HttpPatch("{productID}")]
	public ActionResult PatchProduct(int categoryID, 
		int productID, 
		JsonPatchDocument<ProductForUpdateDTO> patchDocument) {

		var category = MyDataStore.Current.Categories.FirstOrDefault(c => c.ID == categoryID);
		if (category == null) {
			return NotFound("Category not found inorder to update the product");
		}

		var product = category.Products.FirstOrDefault(p => p.ID == productID);
		if (product == null) {
			return NotFound("Product not found");
		}

		var productToUpdate = new ProductForUpdateDTO() {
			Name = product.Name,
			Description = product.Description
		};

		patchDocument.ApplyTo(productToUpdate, ModelState);

		if (!ModelState.IsValid) {
			return BadRequest(ModelState);
		}

		if (!TryValidateModel(productToUpdate)) {
			return BadRequest(ModelState);
		}

		product.Name = productToUpdate.Name;
		product.Description = productToUpdate.Description;

		return NoContent();
	}
}
