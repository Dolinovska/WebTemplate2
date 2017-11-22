﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebTemplate.Database.Models;

namespace WebTemplate.MVC.ViewModels.Products
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Tags")]
        public int[] SelectedTagsIds { get; set; }
        public IEnumerable<Checkbox> TagsCheckboxes { get; set; }

        public ProductEditModel()
        {
        }

        public ProductEditModel(Product product, IEnumerable<Tag> allTags)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            TagsCheckboxes = allTags.Select(p => new Checkbox(p.Name, p.Id.ToString(), false)).ToList();

            TagsCheckboxes.Where(tc => product.Tags.Any(t => t.Name.Equals(tc.Name, StringComparison.OrdinalIgnoreCase))).ToList()
                .ForEach(c => c.IsChecked = true);
        }
    }
}