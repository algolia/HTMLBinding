Overview
=============
This repository allow to bind a string with HTML bold tag (&lt;b&gt; &lt;/b&gt;) in a XAML <em>TextBlock</em> control for Windows 8 (W8HTMLBinding.cs) and Windows Phone 8 (WP8HTMLBinding.cs).

You can customize the way highlighted part of Text property are rendered with <strong>HighlightedBrush</strong> property.

Example
=============

Usage is very easy, you have just to add a namespace in the opening tag of your xaml file:
<pre>
xmlns:algolia="using:AlgoliaSearch"
</pre>

And then to bind a string that contains HTML bold tags:
<pre>
&lt;TextBlock algolia:HTMLBinding.Text="{Binding StringWithBoldTags}"
              algolia:HTMLBinding.HighlightBrush="#52aed9"
              Style="{StaticResource SubheaderTextStyle}"
              TextWrapping="NoWrap"/&gt;
</pre>
