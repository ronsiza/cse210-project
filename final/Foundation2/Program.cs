using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Address _customerAddress;

    public Order(Address customerAddress)
    {
        _products = new List<Product>();
        _customerAddress = customerAddress;
    }

    public void SetProducts(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in _products)
        {
            totalPrice += product.GetPrice();
        }

        if (_customerAddress.IsInUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string PackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()} {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string ShippingLabel()
    {
        return $"{_customerAddress.DisplayAddressInformation()}\n";
    }
}

public class Product
{
    public string _name;
    public string _productId;
    public float _price;
    public float _quantity;

    public Product(string name, string productId, float price, float quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetPrice()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}

public class Customer
{
    private string _name;
    private Address _address;
    private string _location;

    public Customer(string name, Address address, string location)
    {
        _name = name;
        _address = address;
        _location = location;
    }

    public bool IsCustomerInUSA()
    {
        return _address.IsInUSA();
    }
}

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string DisplayAddressInformation()
    {
        return $"{_street}\n{_city}\n{_state}\n{_country}";
    }
}

class Program
{
    static void Main()
    {
        Product product1 = new Product("Laptop", "P001", 1200, 2);
        Product product2 = new Product("Mouse", "P002", 20, 3);

        Address customerAddress = new Address("123 Main St", "Anytown", "CA", "USA");

        Customer customer = new Customer("John Doe", customerAddress, "USA");

        Order order = new Order(customerAddress);
        order.SetProducts(product1);
        order.SetProducts(product2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.PackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.ShippingLabel());

        double totalPrice = order.GetTotalPrice();
        Console.WriteLine($"Total Price: ${totalPrice}");

        Console.ReadLine();
    }
}
