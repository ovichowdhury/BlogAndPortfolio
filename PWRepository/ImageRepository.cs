using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public int Update(Image img)
        {
            Image image = this.Get(1);
            image.imageUrl = img.imageUrl;
            return this.context.SaveChanges();
        }
    }
}
