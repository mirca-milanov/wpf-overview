# WPF Overview
This project is meant to cover every major topic of WPF framework.
## Topics Covered:
* Controls
  * Text
  * Button
  * Input
  * Media
  * Container
* Panels
  * Canvas
  * StackPanel
  * WrapPanel
  * Grid
  * Dock
* Data
  * Resources
  * Data Binding
  * ContentControl
  * ItemsControl
  * DataContext
  * ItemsSource
* Designing
  * Style
  * Transform
  * Triggers
  * Events
  * Animations
* Property
  * DependencyProperty
  * AttachedProperty
* Architecture
  * Visual & Logical Tree
  * Object Hierarchy
* Template
  * DataTemplate
  * ControlTemplate
* Collection Controls
  * ItemsControl
  * ComboBox
  * ListBox
  * ListView
  * TreeView
  * DataGrid
  * Sorting, filtering & grouping data
* Windows
  * Windows
  * Dialogs
* Value Converters
* Validation
  * Exception Validation
  * ValidationRule
  * IDataErrorInfo
  * Annotation Validation
  * INotifyDataErrorInfo
* MVVM
  * Commands
  * INotifyPropertyChanged
  * ObservableCollection
  * View & ViewModel
* Hotkeys
  * Access Keys
  * Key Bindings
* Long running tasks
  * Delayed UI Update
  * REST Client
  * Database Client
  * Canvas Draw
* Custom Controls
  * UserControl
  * CustomControl
* Localization
* Deployment
  * MSI
  * Squirrel
  * Wix
## Additional Notes:
Something & PreviewSomething for Bubble & Tunnel event variation names

Binding: DataContext, Element, Relative

Trigger: Property, Data, Event

Animation: EventTrigger, Actions, BeginStoryboard, StoryBoard, DoubleAnimation, TargetProperty

Dependency Property: DependencyObject, propdb snippet, GetValue & SetVale methods, built in validation, data binding, animation

Attached Property: propa snippet, used in descendant controls, example Grid.Row=2

Object Hierarchy: DispatcherObject, DependencyObject, Visual, UIElement, FrameworkElement, Control, ItemsControl, ContentControl

ControlTemplate: ContentPresenter & ItemsPresenter, \{TemplateBinding Background} & RelativeSource=\{RelativeSource TemplatedParent}

ListView: ListViewItem or ListView.View > GridView, GridView.Columns, GridViewColumn (Header & DisplayMemberBinding=\{Binding FirstName}), CellTemplate

DataGrid: DataGrid.Columns, DataGridText/Template/CheckBox/ComboBox/HyperlinkColumn, CellTemplate, AutoGenerateColumns

Sorting, Filtering & Grouping : CollectionView, CollectionViewSource, CollectionViewSource.GetDefaultView(dataGrid.ItemsSource), SortDescription, Filter predictate, GroupDescription

Validation: TextBlock visibility with binding path to (Validation.HasError) & BooleanToVisibilityConverter

(Validation.Errors)[0].ErrorContent to display error message

When Binding there are additional properties, that we need to set if validation is used

INotifyDataErrorInfo: Beyond HasErrors, GetErrors & ErrorsChanged, we need to add custom Validation method, that takes property name & setter value as parameters & Dictionary<string, List\<string>> errors, which container every error in model, and where each key is property name. Doing it some other way, has high chance of exceptions

HasErrors returns true if any key in dictionary has one or more errors

GetErrors returns list from dictionary based on key/property name

CustomValidation method takes property name & setter value as parameters. Removes key for that property from errors. List\<ValidationResult> containers potential new errors. Validator.TryValidateProperty(value, new ValidationContext(this)\{MemberName = propertyName}, validationResult). After that if validationResult list has errors, add ErrorMessage property to dictionary using Linq.ForEach

Xaml TextBox that is getting validated needs to have properties: NotifyOnValidationError=True, ValidatesOnNotifyDataErrors=True. ItemsControl showing errors should use (Validation.HasError) & (Validation.Errors) for ItemsSource, ErrorContent for DataTemplate

Routed Command: Static type that contains public, static, readonly fields of RoutedCommand type. In XAML, container like Window or StackPanel have InputBindings & CommandBindings. Input needs command & key combination, CommandBinding needs same command, and execute & canexecute event handlers. Down the logical tree we can have button that has same command. CommandTarget property is e.Source in EventHandler's event args and needs to be set with Binding & ElementName

ViewModels Communication: ViewModelA needs to send data to ViewModelB. This can be solved with Mediator Design Pattern. ViewModels share Mediator instance, or get one from it's static property. ViewModelA calls Mediator.Default.Send(book), that method invoked Action\<Book>, that Action property is set by ViewModelB in constructor, calling Mediator.Default.Register(Action that is specified here)

ViewModels Communication Example: ViewA creates Book instance, ViewB shows all books. ViewA can create book and with Mediator send it to ViewB. ViewB has set Action for Mediator, that is going to be performed when Book is sent

ViewModels & DelegateCommands: DelegateCommands work well with ViewModels, because they can access properties of that ViewModel. Set DelegateCommand instance in ViewModel constructor, so that it can access object properties

Delayed UI Update: Thread, Asynchronous method, Method calling Task, BackgroundWorker instance

Canvas Shape Drawing Performance: Creating Line object, and adding it to the Canvas (myCanvas.Children.Add(myLine)) is very slow, has bad performance. Performance improvement tips: RenderOptions.SetEdgeMode(this, EdgeMode.Aliased) in Window or Canvas increases performance massively. Second path is about using DrawingVisual, DrawingContext, DrawingContext.Draw methods, Pens & Brushes should be freezed, custom FrameworkElement to contain all of that, and be added to the Canvas in the end.