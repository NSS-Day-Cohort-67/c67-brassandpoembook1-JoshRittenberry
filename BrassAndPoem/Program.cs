
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Reflection.Metadata;

List<Product> products = new List<Product>()
{
    new Product { Name = "Trumpet", Price = 299.99m, ProductTypeId = 1 },
    new Product { Name = "Trombone", Price = 349.50m, ProductTypeId = 1 },
    new Product { Name = "French Horn", Price = 499.99m, ProductTypeId = 1 },
    new Product { Name = "Cornet", Price = 250.00m, ProductTypeId = 1 },
    new Product { Name = "Baritone Horn", Price = 550.00m, ProductTypeId = 1 },
    new Product { Name = "Euphonium", Price = 600.00m, ProductTypeId = 1 },
    new Product { Name = "The Odyssey", Price = 15.99m, ProductTypeId = 2 },
    new Product { Name = "Divine Comedy", Price = 20.00m, ProductTypeId = 2 },
    new Product { Name = "Paradise Lost", Price = 18.50m, ProductTypeId = 2 },
    new Product { Name = "Iliad", Price = 14.99m, ProductTypeId = 2 },
    new Product { Name = "Beowulf", Price = 12.95m, ProductTypeId = 2 },
    new Product { Name = "Aeneid", Price = 16.00m, ProductTypeId = 2 },
    new Product { Name = "Sonnets by Shakespeare", Price = 19.99m, ProductTypeId = 2 }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType { Title = "Brass", Id = 1 },
    new ProductType { Title = "Poem", Id = 2 }
};

//put your greeting here
string greeting = ("Welcome to Brass and Poem!");

//implement your loop here
string menuSelection = "0";

while (true)
{
    switch (menuSelection)
    {
        case "0":
            DisplayMenu();
            break;
        case "1":
            DisplayAllProducts(products, productTypes);
            menuSelection = "0";
            break;
        case "2":
            DeleteProduct(products, productTypes);
            menuSelection = "0";
            break;
        case "3":
            AddProduct(products, productTypes);
            menuSelection = "0";
            break;
        case "4":
            UpdateProduct(products, productTypes);
            menuSelection = "0";
            break;
        case "5":
            Console.WriteLine("Goodbye!!");
            return;
        default:
            Console.WriteLine(@"
That is not a valid selection! Please try again!!
");
            DisplayMenu();
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine(@$"{greeting}

Site Navigation:
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
");

    Console.Write("Please provide the number of the selection you wish to make: ");
    menuSelection = Console.ReadLine().Trim();
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"
All Products:");
    foreach (Product product in products)
    {
        Console.WriteLine(@$"{products.IndexOf(product) + 1}. {product.Name}, a {productTypes.FirstOrDefault(productType => productType.Id == product.ProductTypeId).Title} product, is for sale for ${product.Price}.");
    }
    Console.WriteLine("");
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    string userInput = null;
    while (userInput != "0")
    {
        DisplayAllProducts(products, productTypes);
        Console.Write("Please provide the product number you wish to delete or type '0' to exit: ");
        userInput = Console.ReadLine().Trim();
        if (userInput == "0")
        {
            Console.WriteLine("");
            return;
        }
        else if (int.TryParse(userInput, out _) && int.Parse(userInput) <= products.Count)
        {
            Console.WriteLine("");
            Product selectedProduct = products.FirstOrDefault(product => products.IndexOf(product) == int.Parse(userInput) -1);
            Console.WriteLine(@$"You have removed {selectedProduct.Name}.
            ");
            products.RemoveAt(products.IndexOf(selectedProduct));
            return;
        }
        else
        {
            Console.WriteLine(@"
That is not a valid selection! Please try again!!");
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    string userInput = null;

    string NewProductName = null;
    decimal NewProductPrice = 0.00M;
    int NewProductTypeId = 0;
    
    Console.WriteLine(@$"
You have chose to add a new product...
    ");

    // product name
    while (true)
    {
        Console.Write("Please provide the product Name: ");
        userInput = Console.ReadLine().Trim();
        if (!int.TryParse(userInput, out _))
        {
            NewProductName = userInput;
            break;
        }
        else 
        {
            Console.Write(@"
This is not a valid Name!!

");
        }
    }

    // product price
    while (true)
    {
        Console.Write("Please provide the Price of the product: $");
        userInput = Console.ReadLine().Trim();
        if (decimal.TryParse(userInput, out _) && decimal.Parse(userInput) > 0)
        {
            NewProductPrice = decimal.Parse(userInput);
            break;
        }
        else 
        {
            Console.Write(@"
This is not a valid Price!!

");
        }
    }

    // product type
    while (true)
    {
        Console.WriteLine(@$"
Product Types:
1. Brass
2. Poem
");
        Console.Write("Please provide the Product Type (either 1 or 2): ");
        userInput = Console.ReadLine().Trim();
        if (int.TryParse(userInput, out _) && int.Parse(userInput) > 0 && int.Parse(userInput) < 3)
        {
            NewProductTypeId = int.Parse(userInput);
            break;
        }
        else 
        {
            Console.Write(@"
This is not a valid Product Type!!
");
        }
    }

    // add product
    Product newProduct = new Product()
    {
        Name = NewProductName,
        Price = NewProductPrice,
        ProductTypeId = NewProductTypeId
    };
    products.Add(newProduct);
    Console.WriteLine(@$"You have created {newProduct.Name}!!
    ");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    string userInput = null;
    Product selectedProduct = new Product();
    
    // select product
    while (true)
    {
        DisplayAllProducts(products, productTypes);
        Console.Write("Please provide the product number you wish to update or type '0' to exit: ");
        userInput = Console.ReadLine().Trim();
        if (userInput == "0")
        {
            Console.WriteLine("");
            return;
        }
        else if (int.TryParse(userInput, out _) && int.Parse(userInput) <= products.Count)
        {
            Console.WriteLine("");
            selectedProduct = products.FirstOrDefault(product => products.IndexOf(product) == int.Parse(userInput) - 1);
            Console.WriteLine(@$"You have selected {selectedProduct.Name}.

Name: {selectedProduct.Name}
Price: ${selectedProduct.Price}
Product Type: {productTypes.FirstOrDefault(productType => productType.Id == selectedProduct.ProductTypeId).Title}
");
            break;
        }
        else
        {
            Console.WriteLine(@"
That is not a valid selection! Please try again!!");
        }
    }

    // edit product
    while (true)
    {
        // product name
        while (true)
        {
            Console.Write(@$"Please provide the updated Product Name or leave this option blank to keep the Product Name {selectedProduct.Name}: ");
            userInput = Console.ReadLine().Trim();
            if (userInput == "")
            {
                break;
            }
            else if (!int.TryParse(userInput, out _))
            {
                selectedProduct.Name = userInput;
                break;
            }
            else
            {
                Console.Write(@"
This is not a valid Name!!

");
            }
        }

        // product price
        while (true)
        {
            Console.Write(@$"Please provide the updated Product Price or leave this option blank to keep the Product Price ${selectedProduct.Price}: $");
            userInput = Console.ReadLine().Trim();
            if (userInput == "")
            {
                break;
            }
            else if (decimal.TryParse(userInput, out _) && decimal.Parse(userInput) > 0)
            {
                selectedProduct.Price = decimal.Parse(userInput);
                break;
            }
            else 
            {
                Console.Write(@"
This is not a valid Price!!

");
            }
        }

        // product type
        while (true)
        {
            Console.WriteLine(@$"
Product Types:
1. Brass
2. Poem
");
            Console.Write(@$"Please provide the updated Product Type or leave this opetion blank to keep the Product Type {productTypes.FirstOrDefault(productType => productType.Id == selectedProduct.ProductTypeId).Title}: ");
            userInput = Console.ReadLine().Trim();
            if (userInput == "")
            {
                break;
            }
            else if (int.TryParse(userInput, out _) && int.Parse(userInput) > 0 && int.Parse(userInput) < 3)
            {
                selectedProduct.ProductTypeId = int.Parse(userInput);
                break;
            }
            else
            {
                Console.Write(@"
This is not a valid Producty Type!!

");
            }
        }

        return;
    }
}

// don't move or change this!
public partial class Program { }