# ElmiDemos
Collection of small samples for testing out solutions using Elmish.WPF

The two projects currently in this solution are both attempts at using ListBox with SelectionMode="Extended" with Elmish.WPF.

MultiSel tries to propagate ListBoxItem.IsSelected to a CheckBox.IsChecked in the item's template through a binding, and from
there on to the model through a second binding. The two bindings work well when not combined, but in combination the binding
to the model fails. See the comments in the XAML for more details.

MultiSel2 tries to bind ListBoxItem.IsSelected directly to the submodel for the items. This causes binding errors at runtime,
and eventually an exception. See the comment in the XAML for more details.

If MultiSel2 only needs a minor modification, then that seems to be the most tidy solution. MultiSel depends on a component
to link IsSelected to the submodel, which is dirty.
