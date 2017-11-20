using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ImageRepository : IImageRepository
    {
        private DataAccessContext context;

        public ImageRepository()
        {
            this.context = new DataAccessContext();
        }
        public Image Get()
        {
            List<Image> image = this.context.ImageInfo.ToList();
            return image[0];
        }

        public int Update(Image img)
        {
            Image image = this.Get();
            image.imageUrl = img.imageUrl;
            return this.context.SaveChanges();
        }
    }
}
