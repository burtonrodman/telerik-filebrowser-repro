using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelerikFileBrowserRepro.Controllers
{

    [Route("api/docupload")]
    public class DocUploadController : ControllerBase
    {
        [HttpPost("read")]
        public JsonResult OnPostRead()
        {
            var docs = new FileBrowserEntry[] {
                new FileBrowserEntry() {
                    Name = "file name from OnPostRead",
                    Size = 100,
                    EntryType = "f"
                }
            };
            return new JsonResult(docs);
        }

        [HttpPost("uploadurl")]
        public virtual ActionResult OnPostUploadFile(string path, IFormFile file)
        {

            return new JsonResult(new FileBrowserEntry()
            {
                Name = "SERVERGENERATED",
                Size = 100,
                EntryType = "f"
            });
        }

    }
}