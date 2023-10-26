namespace GetPriceUrl.Service
{
    public class SelectorByDomain
    {
        public static IDictionary<string, string> _selector { get; } = new Dictionary<string, string>
        {
            { "laptop88.vn", ".price" },
            { "fptshop.com.vn", ".st-price-main" },
            { "phongvu.vn", ".att-product-detail-latest-price" },
            { "cellphones.com.vn", ".tpt---sale-price" },
            { "hacom.vn", ".giakm" },
            { "thegioididong.com", ".box-price-present" },
            { "dienmayxanh.com", ".box-price-present" },
            { "gearvn.com", ".pro-price" },
            { "anphatpc.com.vn", ".js-pro-total-price" },
        };
    }
}
