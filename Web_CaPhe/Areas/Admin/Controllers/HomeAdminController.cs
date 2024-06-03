using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Web_CaPhe.Data;

namespace Web_CaPhe.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly CoffeeshopDbContext _db;
         
        public HomeAdminController(CoffeeshopDbContext context)
        {
            _db = context;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            if (_db == null)
            {
                return NotFound();
            }
            return View();
        }

        [Route("danhmucsanpham")]
        public async Task<IActionResult> DanhMucSanPham()
        {
            var orders = await _db.Order.ToListAsync();
            return View(orders);
        }

        [HttpPost]
        [Route("timkiem")]
        public IActionResult TimKiem(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                // Nếu không có email được nhập, trả về danh sách đơn hàng đầy đủ
                return RedirectToAction("DanhMucSanPham");
            }

            // Thực hiện tìm kiếm đơn hàng dựa trên địa chỉ email mới được nhập
            var orders = _db.Order.Where(o => o.Email.Contains(email)).ToList();
            return View("DanhMucSanPham", orders);
        }
    }
}
