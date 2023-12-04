using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using UserManagementApp.Models;

namespace UserManagementApp.Pages
{
    public class UserManagementModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; } = new User();

        public List<User>? UserList { get; set; }

        public async Task OnGet()
        {
            await LoadUserList();
        }

        public async Task<IActionResult> OnPost()
        {
            // Send a POST request to the API to save the user
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(User), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5238/api/User", content);

                if (response.IsSuccessStatusCode)
                {
                    // If the user is saved successfully, refresh the user list
                    await LoadUserList();
                    User ??= new User();  // Assign only if User is null

                    // Set a success notification
                    TempData["NotificationMessage"] = "User saved successfully!";
                    TempData["NotificationClass"] = "alert-success";
                }
                else
                {
                    // Handle errors
                    ModelState.AddModelError(string.Empty, "Failed to save user.");

                    // Set an error notification
                    TempData["NotificationMessage"] = "Failed to save user.";
                    TempData["NotificationClass"] = "alert-danger";
                }

                return Page();
            }
        }


        private async Task LoadUserList()
        {
            // Fetch the list of users from the API
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("http://localhost:5238/api/User");
                UserList = JsonConvert.DeserializeObject<List<User>>(response);
            }
        }
    }
}
