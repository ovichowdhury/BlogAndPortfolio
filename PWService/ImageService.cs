using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class ImageService : Service<Image>, IImageService
    {
        IImageRepository repo = new ImageRepository();
        public Image Get()
        {
            return this.Get(1);
        }


        public int Update(Image img)
        {
            return this.repo.Update(img);
        }
    }
}
