using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SpellsReference.Models.ViewModels
{
    public class SpellListViewModel
    {
        public int? Level { get; set; }
        public SchoolOfMagic School { get; set; }
        public List<Spell> Spells { get; set; }

        public List<SelectListItem> SchoolSelectItems
        {
            get
            {
                var items = new List<SelectListItem>();
                items.Add(new SelectListItem() { Text = "--", Value = "", Selected = true });
                //Enum.GetValues(typeof(SchoolOfMagic)).ForEach();
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
                var list = Enumerable.Range(1, 9).Select(num => new SelectListItem() { Text = num.ToString() });
                items.AddRange(list);
                return items;
            }
        }
    }
}