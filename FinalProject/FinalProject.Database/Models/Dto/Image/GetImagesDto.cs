using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Models.Dto.Image
{
    public class GetImagesDto
    {
        public Dictionary<string, byte[]> Images { get; set; } = new Dictionary<string, byte[]>();
    }
}
