namespace GetPriceUrl.Helpers
{
    public class SelectorByDomain
    {
        public static IDictionary<string, IDictionary<string, string>> _selectors { get; } = new Dictionary<string, IDictionary<string, string>>()
        {
            { "laptop88.vn", new Dictionary<string, string>()
                {
                    {"currentPrice", "body > main > div.product-detail > div > div.main-product-detail.d-flex > div.main-product-mid > div.box-deal-detail.d-flex.align-items.space-between > div.price-deal-left > div.price"},
                    {"oldPrice", "body > main > div.product-detail > div > div.main-product-detail.d-flex > div.main-product-mid > div.box-deal-detail.d-flex.align-items.space-between > div.price-deal-left > div.main-price.d-flex.align-items > del"}
                }
            },
            { "fptshop.com.vn", new Dictionary < string, string >()
                {
                    { "currentPrice", "#root > main > div > div.l-pd-header > div:nth-child(2) > div.l-pd-row.clearfix > div.l-pd-right > div.st-price > div.st-price__left > div.st-price-main" },
                    { "oldPrice", "#root > main > div > div.l-pd-header > div:nth-child(2) > div.l-pd-row.clearfix > div.l-pd-right > div.st-price > div.st-price__left > div.st-price-sub > strike" }
                }
            },
            { "phongvu.vn", new Dictionary < string, string >()
                {
                    { "currentPrice", "#__next > div > div > div > div > div:nth-child(4) > div > div > div:nth-child(2) > div.css-1hwtax5 > div > div > div.css-6b3ezu > div.css-2zf5gn > div.att-product-detail-latest-price.css-roachw" },
                    { "oldPrice", "#__next > div > div > div > div > div:nth-child(4) > div > div > div:nth-child(2) > div.css-1hwtax5 > div > div > div.css-6b3ezu > div.css-2zf5gn > div.css-3mjppt > div.att-product-detail-retail-price.css-18z00w6" }
                }
            },
            { "cellphones.com.vn", new Dictionary < string, string >()
                {
                    { "currentPrice", "#trade-price-tabs > div > div > div.tpt-box.has-text-centered.is-flex.is-flex-direction-column.is-flex-wrap-wrap.is-justify-content-center.is-align-items-center.active > p.tpt---sale-price" },
                    { "oldPrice", "#trade-price-tabs > div > div > div.tpt-box.has-text-centered.is-flex.is-flex-direction-column.is-flex-wrap-wrap.is-justify-content-center.is-align-items-center.active > p.tpt---price" }
                }
            },
            { "hacom.vn", new Dictionary < string, string >()
                {
                    { "currentPrice", "#js-pd-price" },
                    { "oldPrice", ".old-price" }
                }
            },
            { "thegioididong.com", new Dictionary < string, string >()
                {
                    { "currentPrice", ".box-price-present" },
                    { "oldPrice", "#product-info-price > div.gia-thang-5 > strong.giany" }
                }
            },
            { "dienmayxanh.com", new Dictionary < string, string >()
                {
                    { "currentPrice", "body > section.detail.detail_44 > div.box_main > div.box_right > div.box04.box_normal > div.price-one > div > p.box-price-present" },
                    { "oldPrice", "body > section.detail.detail_44 > div.box_main > div.box_right > div.box04.box_normal > div.price-one > div > p.box-price-old" }
                }
            },
            { "gearvn.com", new Dictionary < string, string >()
                {
                    { "currentPrice", "#detail-product > div.product-body > div > div > div:nth-child(1) > div > div > div > div.col-lg-7.col-md-12.col-12.product-info > div > div > div > div.info-bottom > div.product-price.has-countdown > span.pro-price" },
                    { "oldPrice", "#detail-product > div.product-body > div > div > div:nth-child(1) > div > div > div > div.col-lg-7.col-md-12.col-12.product-info > div > div > div > div.info-bottom > div.product-price.has-countdown > del" }
                }
            },
            { "anphatpc.com.vn", new Dictionary < string, string >()
                {
                    { "currentPrice", "body > section > div.container > div.bg-white.product-info-container > div.pro-info-center > div.pro_info-price-container > table > tbody > tr:nth-child(2) > td:nth-child(2) > b" },
                    { "oldPrice", "body > section > div.container > div.bg-white.product-info-container > div.pro-info-center > div.pro_info-price-container > table > tbody > tr:nth-child(1) > td:nth-child(2) > del" }
                }
            },
        };
    }
}
