using System;
using Gtk;

namespace localDirectory
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class View : Gtk.Bin
	{
		public View ()
		{
			this.Build ();
			this.list.AppendColumn ("Files", new CellRendererText (), "text", 0);
			this.cbRecursive.Active = LocalDirectory.getRecursive();
			fillList();
		}

		protected void onRecursiveToggled (object sender, System.EventArgs e)
		{
			LocalDirectory.setRecursive((sender as ToggleButton).Active);
		}

		protected void onClear (object sender, System.EventArgs e)
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(
				null,Gtk.DialogFlags.Modal,Gtk.MessageType.Question,
				Gtk.ButtonsType.YesNo,"Limpar lista?","");
			if(dialog.Run() == (int)ResponseType.Yes)
			{
				LocalDirectory.clearDirectories();
				fillList();
			}
			dialog.Destroy();
		}

		protected void OnRemove (object sender, System.EventArgs e)
		{
			TreeSelection sel = this.list.Selection;
			TreeModel model;
			TreeIter iter;
			sel.GetSelectedRows(out model);
			if(!sel.GetSelected(out iter))
				return;
			
			int index = model.GetPath(iter).Indices[0];
			//
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(
				null,Gtk.DialogFlags.Modal,Gtk.MessageType.Question,
				Gtk.ButtonsType.YesNo,"Remover \""+LocalDirectory.getDirectory(index)+"\"?","");
			if(dialog.Run() == (int)ResponseType.Yes)
			{
				LocalDirectory.removeDirectory(index);
				fillList();
			}
			dialog.Destroy();
			//
		}

		protected void onAdd (object sender, System.EventArgs e)
		{
			String[] items = {};
			FileChooserDialog dialog = 
				new FileChooserDialog("Open",
				     null,
					FileChooserAction.SelectFolder,
					"Cancel",ResponseType.Cancel,
		            "Open",ResponseType.Accept);
			dialog.SelectMultiple=true;
			if(dialog.Run()==(int)ResponseType.Accept)
			{
				items = dialog.Filenames;
			}
			dialog.Destroy();
			LocalDirectory.addDirectories(items);
			fillList();
		}
		
		private void fillList()
		{
			TreeStore store = new TreeStore(typeof(String));
			foreach(String item in LocalDirectory.getDirectories())
				store.AppendValues(item);
			this.list.Model = store;
			this.list.ShowAll();
		}
	}
}

