using System;
using Acme.Common;
using static Acme.Common.LoggingService;


namespace Acme.Biz
{
    // default with no access modifier is internal

    
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {

        public const double InchesPerMeter = 39.37;

        #region Constructors
        public Product()
        {
            Console.WriteLine("Contrcutor Invoked");

            // Product will always instantiate Vendor
            // this.ProductVendor = new Vendor();
            
        }

        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("parameter constructor invoked");
        }
        #endregion Constructors

        #region Properties

        private DateTime? availabilityDateTime;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDateTime; }
            set { availabilityDateTime = value; }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                // Lazy Loading
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }


        #endregion Properties

        public string SayHello()
        {
            // can call because the vendor class is in the same namespace
            // as this class

            // instatiating the vendor only needed in the class within this method
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("Subject", this.ProductName, "Recipient@mail.com");

            // using static feature to call static method
            var result = LogAction("saying hello method in Product");

            return "Hello " + ProductName +
                   " (" + ProductId + "): " + Description + 
                   " Available on: " +
                   AvailabilityDate?.ToShortDateString();
        }


    }
}
