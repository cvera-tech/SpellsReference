using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SpellsReference.Models.ViewModels
{
    public class SpellFilterViewModel
    {
        public int? Level { get; set; }
        public SchoolOfMagic? School { get; set; }

        public List<SelectListItem> SchoolSelectItems
        {
            get
            {
                var items = new List<SelectListItem>();
                items.Add(new SelectListItem() { Text = "", Value = "" });
                foreach (SchoolOfMagic school in Enum.GetValues(typeof(SchoolOfMagic)))
                {
                    items.Add(new SelectListItem()
                    {
                        Text = school.ToString()
                    });
                }
                return items;
            }
        }

        public List<SelectListItem> LevelSelectItems
        {
            get
            {
                var items = new List<SelectListItem>();
                items.Add(new SelectListItem() { Text = "Cantrip", Value = "0" });
                for (int i = 1; i < 10; i += 1)
                {
                    items.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
                }
                return items;
            }
        }

        public bool HasValues
        {
            get
            {
                return Level.HasValue || School.HasValue;
            }
        }
    }
}