   M S B A M L   `   `   `  ����Y  UlkPangilinan.RetailApp.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:lkPangilinan.RetailApp.Windows.Orders%lkPangilinan.RetailApp.Windows.Orders  5   	   5    /lkPangilinan.RetailApp.Windows.Orders.OrderList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:lkPangilinan.RetailApp.Windows.Orders     5   	     � Title$  	OrderList��5   	   $	��450��6   $	��800��6(   .��5	      � .+�5
   
   �� -   5         ��Name$ btnLast��5
      $
��Last��6"   $
��Left=�61   $��27��6L   $��532,382,0,0q�6X   $	��Top=�6m   $	��133��6�   6�   �� 5   
   -   5        $ btnNext��5      $
��Next��6"   $
��Left=�61   $��27��6L   $��365,382,0,0q�6X   $	��Top=�6m   $	��133��6�   6�   �� 5   
   -   5        $ btnPrev��5      $��Previous��6"   $
��Left=�65   $��27��6P   $��186,382,0,0q�6\   $	��Top=�6q   $	��133��6�   6�   �� 5   
   -   5        $ btnFirst��5      $��First��6#   $
��Left=�63   $��27��6N   $��
20,382,0,0q�6Z   $	��Top=�6n   $	��133��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgCustomers��5      $
��Left=�6(   $	��324��6C   $��	10,36,0,0q�6P   $	��Top=�6c   $	��655��6{   �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��26��6@   $��
104,10,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��561��6�   6�   �� 5   
   -   5        $ txtPageSize��5      $
��Left=�6'   $��26��6B   $��687,334,0,0q�6N    �� TextAlignment$ Center=�6c   $
 Wrap=�6z   $��5��6�   $	��Top=�6�   $��84��6�   6�   �� 5   
   -   5         ��Name$ lblPageSize��5      $��	Page Size��6%   $
��Left=�69   $��38��6T   $��687,296,0,0q�6`   $	��Top=�6u   $��84��6�   �� 5   
   $��Search:��6   $
��Left=�6"   $	��Top=�6=   $��53,5,0,0q�6U   $��26��6g   $��51��6s   �� 5   
   -	   5         ��Name$ 	cboSortBy��5      $
��Left=�6&   $	��Top=�6A   $	��101��6Y   $��670,103,0,0q�6e   $��26��6�   �� 5   
   -
   5        $ cboSortOrder��5      $
��Left=�6)   $	��Top=�6D   $	��101��6\   $��670,167,0,0q�6h   $��26��6�   �� 5   
   -   5        $ 	lblSortBy��5      $��Sort By:��6#   $
��Left=�66   $��29��6Q   $��
670,68,0,0q�6]   $	��Top=�6q   $	��101��6�   �� 5   
   -   5        $ lblSortOrder��5      $��Sort Order:��6&   $
��Left=�6<   $��29��6W   $��670,132,0,0q�6c   $	��Top=�6x   $	��101��6�   �� 5   
   -   5        $ btnAdd��5      $��Add New��6!   $
��Left=�63   $��27��6N   $��687,382,0,0q�6Z   $	��Top=�6o   $��84��6�    J� RenderTransformOrigin$ 0.603,-0.594&�6�   5      5      