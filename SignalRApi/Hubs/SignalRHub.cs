using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalRApi.Hubs
{
    //Hub sunucu görevi görecek.
    //Cors politikası nedir
    // Cross origin request sharing => Tarayıcılar kullanıcıyı korumak üzere kullanıcı bir sitede gezinti yaparken igili sitenin başka bir siteye web isteği yapmasına sınırlama getirir. 
    // SOP ile tarayıcılar, kötü niyetli xyz.com kullanıcının aynı tarayıcı ile açtığı diğer sitelerdeki bilgileri oturum çerezleri üzerinden çalmasını engellemiş olur. 

    // API oluşturken bizim istediğimiz method ve özelliklerin açılmasına olanak sağlayan CORS politikasıdır. 

    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMenuTableService _menuTableService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IBookingService _bookingService;
        private readonly IOrderService _orderService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMenuTableService menuTableService, IMoneyCaseService moneyCaseService, IBookingService bookingService, IOrderService orderService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _menuTableService = menuTableService;
            _moneyCaseService = moneyCaseService;
            _bookingService = bookingService;
            _orderService = orderService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);

            var value4 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value4);

            var value5 = _categoryService.TActiveCategory();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value5);

            var value6 = _categoryService.TPassiveCategory();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value6);

            var value7 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value7.ToString("C"));

            var value8 = _productService.TProductNamePriceByMax();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNamePriceByMin();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

            var value10 = _orderService.TOrderTotalCount();
            await Clients.All.SendAsync("ReceiveOrderTotalCount", value10);

            var value11 = _orderService.TLastOrderTotalPrice();
            await Clients.All.SendAsync("ReceiveLastOrderTotalPrice", value11.ToString("C"));

            var value12 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value12.ToString("C"));

            var value13 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value13.ToString("C"));

            var value14 = _productService.TProductPriceByCategory();
            await Clients.All.SendAsync("ReceiveProductPriceByCategory", value14);
        }

        public async Task SendProgressBar()
        {
            var valueP1 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", valueP1.ToString("C"));

            var valueP2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTActiveOrderCount", valueP2);

            var valueP3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", valueP3);

            var valueP4 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", valueP4.ToString("C"));

            var valueP5 = _productService.TProductPriceByCategory();
            await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", valueP5);

            var valueP6 = _orderService.TOrderTotalCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", valueP6);

            var valueP7 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoney", valueP7);

            var valueP8 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayOrderTotalAmount", valueP8);

            var valueP9 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTotalActiveMenuTable", valueP9);

            var valueP10 = _orderService.TCompleteOrderCount();
            await Clients.All.SendAsync("ReceiveCompleteOrderCount", valueP10);
        }

        public async Task GetBookingList()
        {
            var value = _bookingService.TGetListAll();
            await Clients.All.SendAsync("RecieveBookingList", value);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("RecieveNotificationCountByFalse", value);

            var notificationList = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("RecieveGetAllNotificationByFalse", notificationList);
        }

        //TableListByStatus anlık masa durumları safasındaki bölüm
        public async Task GetMenuTableStatusList()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("RecieveGetMenuTableStatusList", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }

        public static int clientCount { get; set; }
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("RecieveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("RecieveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
