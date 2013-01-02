HTMLBinding
===========

Windows 8 and Windows Phone 8 class to bind string with HTML bold tags.

Overview
=============
This repository allow to bind a string with HTML bold tag (&lt;b&gt; &lt;/b&gt;) in a XAML <em>TextBlock</em> control for Windows 8 (W8HTMLBinding.cs) and Windows Phone 8 (WP8HTMLBinding.cs).

You can customize the way highlighted part are rendered with <strong>HighlightedBrush</strong> property.

Example
=============

<pre>
&lt;TextBlock algolia:Binding.Text="{Binding HighlightedName}"
                       algolia:Binding.HighlightBrush="#52aed9"
                       Style="{StaticResource SubheaderTextStyle}"
                       TextWrapping="NoWrap"/&gt;
</pre>
