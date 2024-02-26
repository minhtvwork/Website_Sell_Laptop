﻿using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using Shop_Models.Dto;
using Shop_Models.Entities;
using System.Net.Http.Headers;
namespace AdminApp.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly ILogger<ProductDetailController> _logger;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        List<Product> listProduct;
        Product ProductById;
        List<Color> listColor;
        List<Ram> listRam;
        List<Cpu> listCpu;
        List<HardDrive> listHardDrive;
        List<Screen> listScreen;
        List<CardVGA> listCardVGA;
        public ProductDetailController(ILogger<ProductDetailController> logger, IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _config = config;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> GetList()
        {

            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            var accessToken = Request.Cookies["account"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //string jwtToken = HttpContext.Session.GetString("AccessToken");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            string result = await client.GetStringAsync($"/api/ProductDetail/GetAllPDD");
            return Content(result, "application/json");
        }
        public async Task<IActionResult> GetProductDetail()
        {
            //string jwtToken = HttpContext.Session.GetString("AccessToken");

            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var accessToken = Request.Cookies["account"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string result = await client.GetStringAsync($"/api/ProductDetail/PGetProductDetail");
            return Content(result, "application/json");
        }
        public async Task<IActionResult> Create(Guid id)
        {
            string jwtToken = HttpContext.Session.GetString("AccessToken");

            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            string getProduct = await client.GetStringAsync($"/api/Product");
            ViewBag.GetProduct = JsonConvert.DeserializeObject<List<Product>>(getProduct);
            listProduct = JsonConvert.DeserializeObject<List<Product>>(getProduct);
            string getManufacturer = await client.GetStringAsync($"/api/Manufacturer");
            ViewBag.GetManufacturer = JsonConvert.DeserializeObject<List<Manufacturer>>(getManufacturer);
            string getColor = await client.GetStringAsync($"/api/Color");
            ViewBag.GetColor = JsonConvert.DeserializeObject<List<Color>>(getColor);
            listColor = JsonConvert.DeserializeObject<List<Color>>(getColor);
            string getProductType = await client.GetStringAsync($"/api/ProductType");
            ViewBag.GetProductType = JsonConvert.DeserializeObject<List<ProductType>>(getProductType);
            string getCPU = await client.GetStringAsync($"/api/Cpu");
            ViewBag.GetCPU = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);
            listCpu = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);
            string getRam = await client.GetStringAsync($"/api/Ram");
            ViewBag.GetRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);
            listRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);
            string getHardDrive = await client.GetStringAsync($"/api/HardDrive");
            ViewBag.GetHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);
            listHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);
            string getScreen = await client.GetStringAsync($"/api/Screen");
            ViewBag.GetScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);
            listScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);
            string getlistCardVGA = await client.GetStringAsync($"/api/CardVGA");
            ViewBag.GetlistCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);
            listCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);
            string getProductDetails = await client.GetStringAsync($"/api/ProductDetail/ProductDetailById?id={id}");
            ProductDetail productGetById = JsonConvert.DeserializeObject<ProductDetail>(getProductDetails);
            ViewBag.SelectedProductId = productGetById.ProductId;
            ViewBag.SelectedColorId = productGetById.ColorId;
            //ViewBag.SelectedRamId = productGetById.IdRam;
            //ViewBag.SelectedCPUId = productGetById.IdCpu;
            //ViewBag.SelectedScreenId = productGetById.IdScreen;
            //ViewBag.SelectedHardDriveId = productGetById.IdHardDrive;
            //ViewBag.SelectedCardVGAId = productGetById.IdCardVGA;
            return View(productGetById);

            //return PartialView("Create", productGetById);
            //}         
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");

            string getProduct = await client.GetStringAsync($"/api/Product");
            ViewBag.GetProduct = JsonConvert.DeserializeObject<List<Product>>(getProduct);
            listProduct = JsonConvert.DeserializeObject<List<Product>>(getProduct);

            string getManufacturer = await client.GetStringAsync($"/api/Manufacturer");
            ViewBag.GetManufacturer = JsonConvert.DeserializeObject<List<Manufacturer>>(getManufacturer);

            string getColor = await client.GetStringAsync($"/api/Color");
            ViewBag.GetColor = JsonConvert.DeserializeObject<List<Color>>(getColor);
            listColor = JsonConvert.DeserializeObject<List<Color>>(getColor);

            string getProductType = await client.GetStringAsync($"/api/ProductType");
            ViewBag.GetProductType = JsonConvert.DeserializeObject<List<ProductType>>(getProductType);

            string getCPU = await client.GetStringAsync($"/api/Cpu");
            ViewBag.GetCPU = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);
            listCpu = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);

            string getRam = await client.GetStringAsync($"/api/Ram");
            ViewBag.GetRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);
            listRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);

            string getHardDrive = await client.GetStringAsync($"/api/HardDrive");
            ViewBag.GetHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);
            listHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);

            string getScreen = await client.GetStringAsync($"/api/Screen");
            ViewBag.GetScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);
            listScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);

            string getlistCardVGA = await client.GetStringAsync($"/api/CardVGA");
            ViewBag.GetlistCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);
            listCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);
            string getProductDetails = await client.GetStringAsync($"/api/ProductDetail/ProductDetailById?id={id}");
            ProductDetail productGetById = JsonConvert.DeserializeObject<ProductDetail>(getProductDetails);
            ViewBag.SelectedProductId = productGetById.ProductId;
            ViewBag.SelectedColorId = productGetById.ColorId;
            //ViewBag.SelectedRamId = productGetById.IdRam;
            //ViewBag.SelectedCPUId = productGetById.IdCpu;
            //ViewBag.SelectedScreenId = productGetById.IdScreen;
            //ViewBag.SelectedHardDriveId = productGetById.IdHardDrive;
            //ViewBag.SelectedCardVGAId = productGetById.IdCardVGA;
            return View(productGetById);

            //return PartialView("Create", productGetById);
            //}         
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDetailDto productRequest, string editor)
        {
            if (ModelState.IsValid)
            {
                ProductDetail productDetail = new ProductDetail()
                {
                    Id = Guid.NewGuid(),
                    Code = productRequest.Code,
                    ImportPrice = (float)productRequest.ImportPrice,
                    Price = (float)productRequest.Price,
                    Upgrade = productRequest.Upgrade,
                    Description = editor,
                    Status = 1,
                    ProductId = productRequest.IdProduct,
                    ColorId = productRequest.IdColor,
                    RamId = productRequest.IdRam,
                    CpuId = productRequest.IdCpu,
                    HardDriveId = productRequest.IdHardDrive,
                    ScreenId = productRequest.IdScreen,
                    CardVGAId = productRequest.IdCardVGA,

                };
                var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
                var result = await client.PostAsJsonAsync($"/api/ProductDetail", productDetail);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "ProductDetail");
                }
                return Json(null);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { Errors = errors });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Createaa(ProductDetailDto productRequest, string editor, [FromForm] List<IFormFile> formFiles)
        {
            ProductDetail productDetail = new ProductDetail()
            {
                Id = Guid.NewGuid(),
                Code = productRequest.Code,
                ImportPrice = (float)productRequest.ImportPrice,
                Price = (float)productRequest.Price,
                Upgrade = productRequest.Upgrade,
                Description = editor,
                Status = 1,
                ProductId = productRequest.IdProduct,
                ColorId = productRequest.IdColor == Guid.Empty ? null : productRequest.IdColor,
                RamId = productRequest.IdRam == Guid.Empty ? null : productRequest.IdRam,
                CpuId = productRequest.IdCpu == Guid.Empty ? null : productRequest.IdCpu,
                HardDriveId = productRequest.IdHardDrive == Guid.Empty ? null : productRequest.IdHardDrive,
                ScreenId = productRequest.IdScreen == Guid.Empty ? null : productRequest.IdScreen,
                CardVGAId = productRequest.IdCardVGA == Guid.Empty ? null : productRequest.IdCardVGA,
            };

            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            var accessToken = Request.Cookies["account"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.PostAsJsonAsync($"/api/ProductDetail/CreateReturnDTO", productDetail);

            //string message = await response.Content.ReadAsStringAsync(); // Lấy thông báo từ nội dung
            using (var formData = new MultipartFormDataContent())
            {
                foreach (var file in formFiles)
                {
                    formData.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
            {
                ContentLength = file.Length,
                ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType)
            }
                    }, "files", file.FileName);
                }

                // Add other data if needed
                formData.Add(new StringContent(productDetail.Id.ToString()), "ProductId");

                // Send the request
                var resultImage = await client.PostAsync("https://localhost:44333/api/Images/uploadManyProductDetailImages", formData);
            }


            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return Content(result, "application/json");
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();

                return Content(result, "application/json");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            var response = await client.GetAsync($"/api/ProductDetail/{id}");

            if (response.IsSuccessStatusCode)
            {
                var productDetail = await response.Content.ReadFromJsonAsync<ProductDetailDto>();
                return View(productDetail);
            }
            else
            {
                // Xử lý khi không tìm thấy chi tiết sản phẩm
                return RedirectToAction("Index", "ProductDetail");
            }
        }
        [HttpGet]
        ////[HttpPost]
        public async Task<IActionResult> Index(/*Guid guid*/)
        {
            if (Request.Cookies["account"] == null)
            {
                return RedirectToAction("Index", "Home");
            }



            using (var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin")) {

                //var cookies = Request.Cookies.FirstOrDefault(x => x.Key == "account");

                var accessToken = Request.Cookies["account"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var getProduct = await client.GetStringAsync($"/api/Product");
                ViewBag.GetProduct = JsonConvert.DeserializeObject<List<Product>>(getProduct);
                string getManufacturer = await client.GetStringAsync($"/api/Manufacturer");
                ViewBag.GetManufacturer = JsonConvert.DeserializeObject<List<Manufacturer>>(getManufacturer);
                string getColor = await client.GetStringAsync($"/api/Color");
                ViewBag.GetColor = JsonConvert.DeserializeObject<List<Color>>(getColor);
                listColor = JsonConvert.DeserializeObject<List<Color>>(getColor);
                string getProductType = await client.GetStringAsync($"/api/ProductType");
                ViewBag.GetProductType = JsonConvert.DeserializeObject<List<ProductType>>(getProductType);
                string getCPU = await client.GetStringAsync($"/api/Cpu");
                ViewBag.GetCPU = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);
                listCpu = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);
                string getRam = await client.GetStringAsync($"/api/Ram");
                ViewBag.GetRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);
                listRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);
                string getHardDrive = await client.GetStringAsync($"/api/HardDrive");
                ViewBag.GetHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);
                listHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);
                string getScreen = await client.GetStringAsync($"/api/Screen");
                ViewBag.GetScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);
                listScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);
                string getlistCardVGA = await client.GetStringAsync($"/api/CardVGA");
                ViewBag.GetlistCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);
                listCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);

                return View();
            }
           
           
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            var accessToken = Request.Cookies["account"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var getProductDetails = await client.GetFromJsonAsync<ProductDetail>($"/api/ProductDetail/ProductDetailById?guid={id}");
            var getProductDetailsImages = await client.GetStringAsync($"https://localhost:44333/api/Images/getProductDetailImages2?ProductId={id}");
            var images = JsonConvert.DeserializeObject<List<Image>>(getProductDetailsImages);
            ViewBag.ImagesPD = images;
            return PartialView("_Update", getProductDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDetail getProductDetails/*, string editor*/)
        {
            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            var accessToken = Request.Cookies["account"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //ProductDetail productDetail = new ProductDetail();
            //productDetail.ImportPrice = (float)getProductDetails.ImportPrice;
            //productDetail.Price = (float)getProductDetails.Price;
            //productDetail.Upgrade = getProductDetails.Upgrade;
            //productDetail.Description = getProductDetails.Description;
            var result = await client.PutAsJsonAsync($"/api/ProductDetail/UpdateProductDetail", getProductDetails);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail");
            }
            return RedirectToAction("Index", "ProductDetail");
        }
        public async Task<ActionResult> UpdatePartialView(Guid guid)
        {
            // Logic để lấy dữ liệu sản phẩm dựa trên Id và truyền vào view

            var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
            var getProduct = await client.GetFromJsonAsync<List<Product>>($"/api/Product");
            ViewBag.GetProduct = getProduct;

            string getManufacturer = await client.GetStringAsync($"/api/Manufacturer");
            ViewBag.GetManufacturer = JsonConvert.DeserializeObject<List<Manufacturer>>(getManufacturer);

            string getColor = await client.GetStringAsync($"/api/Color");
            ViewBag.GetColor = JsonConvert.DeserializeObject<List<Color>>(getColor);
            listColor = JsonConvert.DeserializeObject<List<Color>>(getColor);

            string getProductType = await client.GetStringAsync($"/api/ProductType");
            ViewBag.GetProductType = JsonConvert.DeserializeObject<List<ProductType>>(getProductType);

            string getCPU = await client.GetStringAsync($"/api/Cpu");
            ViewBag.GetCPU = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);
            listCpu = JsonConvert.DeserializeObject<List<Cpu>>(getCPU);

            string getRam = await client.GetStringAsync($"/api/Ram");
            ViewBag.GetRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);
            listRam = JsonConvert.DeserializeObject<List<Ram>>(getRam);

            string getHardDrive = await client.GetStringAsync($"/api/HardDrive");
            ViewBag.GetHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);
            listHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(getHardDrive);

            string getScreen = await client.GetStringAsync($"/api/Screen");
            ViewBag.GetScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);
            listScreen = JsonConvert.DeserializeObject<List<Screen>>(getScreen);

            string getlistCardVGA = await client.GetStringAsync($"/api/CardVGA");
            ViewBag.GetlistCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);
            listCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(getlistCardVGA);


            var getProductDetails = await client.GetFromJsonAsync<ProductDetailDto>($"/api/ProductDetail/ProductDetailByIdReturnProDetailDTO?guid={guid}");
            return PartialView(getProductDetails);
        }
        //public IActionResult ImportProductsFromExcel()
        //{
        //    return View();
        //}
        public async Task<IActionResult> ImportProductsFromExcel(IFormFile excelFile)
        {
            try
            {
                using (var package = new ExcelPackage(excelFile.OpenReadStream()))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var products = new List<ProductDetail>();
                    var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var product = new ProductDetail
                        {
                            Id = Guid.NewGuid(),
                            Code = worksheet.Cells[row, 1].Text,
                            Price = float.Parse(worksheet.Cells[row, 2].Text),
                            ImportPrice = float.Parse(worksheet.Cells[row, 3].Text),
                            Upgrade = worksheet.Cells[row, 4].Text,
                            Description = worksheet.Cells[row, 5].Text,
                            Status = int.Parse(worksheet.Cells[row, 6].Text),
                            ProductId = Guid.Parse("D29B5AF1-AF18-4A6C-A4C6-82468DDA11B3"),
                            ColorId = null,
                            RamId = null,
                            CpuId = null,
                            HardDriveId = null,
                            ScreenId = null,
                            CardVGAId = null,
                        };
                        products.Add(product);

                        //if (result.IsSuccessStatusCode)
                        //{
                        //    return RedirectToAction("Index", "ProductDetail");
                        //}

                        //return BadRequest(result);
                    }
                    var result = await client.PostAsJsonAsync($"/api/ProductDetail/CreateMany", products);
                    return RedirectToAction("Index", "ProductDetail");


                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
        [HttpGet("export-products-to-excel")]
        public async Task<IActionResult> ExportProductsToExcel()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PhuongThaoHttpAdmin");
                var getProductDetails = await client.GetFromJsonAsync<ProductDetail>($"/api/ProductDetail/PGetProductDetail");

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("getProductDetails");
                    worksheet.Cells[1, 1].Value = "Code";
                    worksheet.Cells[1, 2].Value = "ImportPrice";
                    worksheet.Cells[1, 3].Value = "Price";
                    worksheet.Cells[1, 4].Value = "Upgrade";
                    worksheet.Cells[1, 5].Value = "Description";
                    worksheet.Cells[1, 6].Value = "Status";
                    int row = 2;
                    //foreach (var product in products)
                    //{
                    //    worksheet.Cells[row, 1].Value = product.Code;
                    //    worksheet.Cells[row, 2].Value = product.ImportPrice;
                    //    worksheet.Cells[row, 3].Value = product.Price;
                    //    worksheet.Cells[row, 4].Value = product.Upgrade;
                    //    worksheet.Cells[row, 5].Value = product.Description;
                    //    worksheet.Cells[row, 6].Value = product.Status;
                    //    row++;
                    //}
                    var memoryStream = new MemoryStream();
                    package.SaveAs(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Products.xlsx");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

    }

}

