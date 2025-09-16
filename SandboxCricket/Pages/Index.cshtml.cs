using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using SandboxCricket.Controller;
using SandboxCricket.Model;

namespace SandboxCricket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public class Brand
        {
            public int BrandId { get; set; }
            public string BrandName { get; set; }
        }

        [BindProperty]
        public int SelectedBrand { get; set; }

        // New property to hold the name of the selected brand for display
        public string SelectedBrandName { get; set; }
        public string BatDetails { get; set; }

        public List<Brand> Brands { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Brands = GetBrands();
        }

        // OnPost handler for the brand selection form
        public IActionResult OnPost()
        {
            Brands = GetBrands(); // Re-populate the brands list

            // Practical solution: Find the name of the selected brand
            var selectedBrand = Brands.FirstOrDefault(b => b.BrandId == SelectedBrand);
            if (selectedBrand != null)
            {
                SelectedBrandName = selectedBrand.BrandName;
            }
            switch (selectedBrand.BrandId)
            {
                case 1:
                    CricketBatFactory GmFactory = new GmFactory();
                    CricketBat Gm = GmFactory.CreateBat();
                    BatDetails = Gm.Details();
                    break;
                case 2:
                    CricketBatFactory MrfFactory = new MRFFactory();
                    CricketBat MRF = MrfFactory.CreateBat();
                    BatDetails = MRF.Details();
                    break;
                case 3:
                    CricketBatFactory KookaburraFactory = new KookaburaFactory();
                    CricketBat Kookaburra = KookaburraFactory.CreateBat();
                    BatDetails = Kookaburra.Details();
                    break;
            }
            // The key change: return the current page
            return Page();
        }

        // You would have another OnPost handler for the second form
        // This is an example of a named handler.
        public IActionResult OnPostOrder(string name, string email)
        {
            _logger.LogInformation("Order received for {BrandId} from {Name} ({Email})", SelectedBrand, name, email);

            // Practical solution: Process the order here, e.g., save to a database.
            // Then, redirect to a confirmation page.
            return RedirectToPage("/OrderConfirmation");
        }

        // Helper method to keep code clean
        private List<Brand> GetBrands()
        {
            return new List<Brand>
            {
                new Brand { BrandId = 1, BrandName = "GM" },
                new Brand { BrandId = 2, BrandName = "MRF" },
                new Brand { BrandId = 3, BrandName = "Kookaburra" }
            };
        }
    }
}