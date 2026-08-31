using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiTests.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
    (
        long id,

        string orderId,

        string productId,

        long quantity,

        long unitPrice
    );
}
