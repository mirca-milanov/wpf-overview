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
* MVVM
  * Commands
  * INotifyPropertyChanged
  * ObservableCollection
  * View & ViewModel
* Hotkeys
  * Access Keys
  * Key Bindings
* Long running tasks
  * Dispatcher
  * DispatcherTimer
  * BackgroundWorker
  * TPL
  * REST Client
  * Database Client
  * Canvas Drawing
* Custom Controls
  * UserControl
  * CustomControl
* Localization
* Deployment
  * MSI
  * Squirrel
  * Wix
## Additional Notes:
Something & PreviewSomething for Bubble & Tunnel event variation names.

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