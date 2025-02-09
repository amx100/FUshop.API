using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.DataTransferObject;

public class ProductSizeDto
{
    public int ProductSizeId { get; set; }
    public int SizeId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }

}

public class ProductSizeCreateDto
{
    public int SizeId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
}

public class ProductSizeUpdateDto
{
    public int SizeId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
}