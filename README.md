# ElmiDemos
Collection of small samples for testing out solutions using Elmish.WPF

The three projects currently in this solution are both attempts at using ListBox with SelectionMode="Extended" with Elmish.WPF.

MultiSel tries unsuccessfully to propagate ListBoxItem.IsSelected to a CheckBox.IsChecked in the item's template through a binding, and from there on to the model through a second binding. The two bindings work well when not combined, but in combination the binding
to the model fails. This is actually expected according to docs. In any case, this demo is not much of interest any longer, because it has the smell of a hack. It tries to go through a component to connect ListBoxItem.IsSelected to the item model.

MultiSel2 binds ListBoxItem.IsSelected directly to the submodel for the items. This works perfectly.

MultiSel3 uses "interaction behaviors", and I've had to use a free library from DevExpress for this. It's the only one with this sort of functionality that I know of that works with .NET Core. This too goes through a component to connect ListBoxItem.IsSelected to the item model, but is still of slight interest just to demo "interaction behaviors".
