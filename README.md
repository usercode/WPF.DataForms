# WPF.DataForms
Fluent-based data forms for WPF

https://www.nuget.org/packages/WPF.DataForms

[![nuget](https://img.shields.io/nuget/v/WPF.DataForms.svg)](https://www.nuget.org/packages/WPF.DataForms)

## General ##

- Every form has groups and fields
- Every form has three states (view, create and edit)
- Every field create different controls depended by state
  - View state: e.g. some controls are just disabled or replaced by non-editable controls.
- Automatic grid layout
  - add or move fields and groups without setting the row and column number
- Easily replace controls without changing mappings

## How to use it ##


1. Create the entity detail viewmodel

```CS
class CustomerDetailViewModel
    {
        public Customer Customer { get; set; }
        
        public DataTemplate Template { get; set; }
        
        //..
    }
```

2. Create the entity detail view and set the data context to the viewmodel instance.

```XAML
<ContentControl Content="{Binding}"
                ContentTemplate="{Binding DataTemplate}"
/>
```

3. Define the mapping for viewmodel

```CS
class CustomerFormMapping : DataFormMapping<CustomerDetailViewModel>
    {
        public override void CreateContent()
        {
            MainContent.Group(Resources.General)
                          .Id(Resources.Id, x => x.Customer.Id)
                          .Bool(Resources.IsActive, x => x.Customer.IsActive)
                          .Text(Resources.Title, x => x.Customer.Title)
                          .Text(Resources.LastName, x => x.Customer.Lastname)
                          .Text(Resources.FirstName, x => x.Customer.Firstname)
                          .Date(Resources.DateOfBirth, x => x.Customer.DOB)
              ;
        }
```

4. Create the data template:

```CS
viewModel.DataTemplate = new CustomerFormMapping ().CreateTemplate(FormState.View);
```
