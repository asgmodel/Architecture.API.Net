using APILAHJA.Dso;
using APILAHJA.Services;
using APILAHJA.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APILAHJA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(InvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        // إنشاء فاتورة جديدة
        [HttpPost("create")]
        public async Task<ActionResult<VMInvoiceOutput>> CreateInvoice([FromBody] VMInvoiceCreate invoiceRequest)
        {
            if (invoiceRequest == null)
            {
                return BadRequest("البيانات المدخلة غير صالحة");
            }

            var item = _mapper.Map<InvoiceRequestDso>(invoiceRequest);
            var result = await _invoiceService.CreateAsync(item);
            var output = _mapper.Map<VMInvoiceOutput>(result);

            if (output == null)
            {
                return StatusCode(500, "حدث خطأ أثناء إنشاء الفاتورة");
            }

            return Ok(output); // إرجاع الفاتورة المنشأة
        }

        // يمكنك إضافة طرق أخرى مثل التحديث أو الحذف حسب الحاجة
    }
}
