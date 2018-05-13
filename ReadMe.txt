Read Me  Acme App


Acme App:
	UI Layer:	Display User Interface
		Acme.Win:	Windows Forms
		Acme.Wpf:	Wpf
		Acme.Web:	Web based user interface

	Business Logic Layer:	Logic for application, add vendors, send order, outside of UI to be used by different UI's
		Acme.Biz:  Class library projects, can break out into smaller projects for different business components

	Data Access Layer: communication with the database, class library, or can use entity framework 
		Acme.Data

	Acme.Common:  Library components for common code for all projects



C# Application "Things"
Domain Entities

A class is a template or mold
Speifies the traits or data
Specifies the behavior or operations

Types of Class:
	UI 
	Domain Entity
	Library Classes


UI Classes
	Form Class
	V/M View/Model in Wpf	MVVM Model View View Model coding pattern


Business Logic: Business Domain Model
	Order, Product, Vendor
	Product has a Vendor

	Repository Classes

Library Compnonent if logic works across layers


Tests
	Unit Tests
		Tests behavior of unit of code
			Often a method
		Automated
		Defined with Code to Identify errors

	Higher Code Quality
		Testable Methods
		Test Cases
		Identity Failures
		Faster and Easier to Debug
		Repeatable

	Unit Testing in Visual Studio
		MSTest
		Nunit
	Steps 
		Define Scenarios
		Valid and Invalid Data
		Generate tests
		Execute Tests

Layered Architecture is important?
	Logical components are easier to create, change, extend, and maintain
	Code is easier to reuse

What is a class?
	A template for the objects created at runtime
	Specifies the data and operations for each entity

Unit Testing Benefits
	Higher code quality, faster and easier debugging, and they are repeatable over the 
	life of the application




BUILDING GOOD CLASSES	

Signature
Members:
	Fields 
	Properties 
	Methods 
	Constructors


	public class Product
	default is internal, by project

	Fields: variables in a class, holds the data
		private fields, no outside code can get or set the values
	
	Properties:	Getter and Setter Functions
		Guard access to the fields
		Encapsulate the fields so only can be used through properties
		Property for each field that needs to be modified

	Methods: Functions containing logic for the class, behaviors and operations


Define meaningful name
User a noun
Use PascalCasing
Use XML documents
Use properties to encap fields
Use methods for logic in the class
Each class has well-defined purpuse
One class per code file
Add properties at the top of the class


Don't:
	Abbreviations
	Prefixes
	Underscores
	Large Classes


shortcut cmd: propfull (tab, tab)
creates field and property

var keyword uses implicit typing
 c# infers variable must be of type 


Constructor
	named the same as the class
	executes when instance is created
	default contructor has no parameters

Paramaterized Constructor
	params to initialize the instance
	Constructor Overloading
	Use "this" to invoke another constructor
	constructor chaining
	minimize repeated code

	ctor (tab, tab)
	creates default constructor

Namespaces
	Provide a unique address
	Organize classes into a logical hierarchy

	company.technology.feature (example)
	use PascalCasing

	Avoid using system in the namespace
	Avoid using a class name in the namespace


Static Classes
	Set of services provided by a set of methods

	static in class signature
	only includes static members
	can not instantiate a static class
	use class name to call methods
	container for utility features

	Use static classes sparingly
		static classes can't:
			have parameterized constructors
			implement an interface
			can't inherit from a static class

	Avoid using static classes as a miscellaneous bucket of adhoc methods

	Use static classes for common library components when needed


Singleton to provide only one instance
	static class can't provide any instances

	private constructor(s)

	add a static property

	ex:

	private static User instance;

	private User() {}
	
	public static User Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new User();
			}
			return instance;
		}
	}

	Call User.Instance to access

	Design Patterns Library on Pluralsight
	If too much, Designs Patterns On-Ramp


Advantages of Singleton vs Static Class
	A singleton has an instance, can be passed to other code as needed
	A singleton can have child objects, User instance has a set of roles associated with it
	Singleton supports object-oriented programming: can implement an interface, can be inherited from


Diff between property and method?
	Properties are the gate-keepers, providing access to the data
	Methods are the operations

Constructor?
	Method executed when an instance is created from a class

Namespace?
	Organizes classes into logical hierarchy
	Prevent class name collisions

Static class?
	Class that can not be instantiated, best for use with common code libraries

Singleton?
	Class that provides a single instance of itself



5.	Accessing and Using Classes

Accessing classes from different component
Do this be defining a references to the component containing the class

Use a "Using Directive" to simplify the code	
	To use the class without the fully qualified namespace

Examples in Product.cs and Vendor.cs

References must be only one way
	Acme.Biz.Product referencing Acme.Common
		if we try to reference Acme.Biz from within Acme.Common, Circular Reference

Take advantage of the using directive

Avoid excessive use of the using static directive



Accessing Class Members

Non-static Class : 
	var currentProduct = new Prodcut();
	var result = currentProduct.SayHello();

Static Class:
	var result = LoggingService.LogAction("");



Object vs. Class

Object:
	Represents one specific thing: ex. Hammer or Saw

	Defines one thing created from that template

	Created at runtime with the new keyword

Class:
	Represents things of the same type: ex. Product

	Defines the template specifying the data processing associated with all things of that type

	Created at development time with code 


Object Initialization

Best Practices

Setting Properties, when populating from database values, when modifying properties values

Parameterized Constructor, setting basic set of properties

Object Initializers, when readability is important, when initializing a subset or superset of properties



Instantiating Related Objects

	One Method
		Initialize in the method that needs it
	Always
		Define a property for the object variable in class that needs it
		Instantiate in the default constructor
	Sometimes
		Define a property for the object variable in class that needs it
		Initialize in the property getter "Lazy Loading"


Null Checking

	Variable is local if within a method
	Backing field with a property 
		define field as private : private Vendor productVendor
		then property as public : public Vendor ProductVendor
									{
										get{return productVendor; }
										set {productVendor = value; }
									}

	// can get tedious
	if (currentProduct != null && currentProduct.ProductVendor != null)
	{
		var companyName = currentProduct.ProductVendor.CompanyName;
	}

	c# 6 Null-Conditional Operator

	var companyName = currentProduct?.ProductVendor?.CompanyName;

	?. Is the null-conditional operator
	removes need for explicit null checking
	Called the "Elvis Operator"
	If null then null, if not then dot


FAQ
	Review
		A class is a template that specifies the data and operations for an entity
		An object is an instance of that class created at runtime using the new keyword

	What is lazy loading?
		Instantiating related objects when they are needed and not before
		This often involves creating the instance in the property getter for the related object



6.	Fields

Backing Field
	A variable in a class
	Holds data for each object

	Data Encapsulation
		Fields are private
		Availabe through property getter and setters

	Optional accessibility modifier, usually private
	Data Type, string int, or Object
	Name
	Optional Initialization

	Do use a meaningful name
	camel casing
	
	Don't need to explicitly initialize

Nullable Type

private decimal? cost;

allows definition of value or null
distinguish between not set and default value

cost 0 is set or not set?
null or 0

Use null with simple types to define "not set" and "default value"


Constants

public const double Pi = 3.14;
static

optional accessiblity modifier
usually public
no property neeed
Constants first letter uppercase
must be initialized


