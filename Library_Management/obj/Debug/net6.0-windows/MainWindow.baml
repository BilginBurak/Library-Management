   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Library_ManagementLibrary_Management  5   	   #    Library_Management.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Library_Management     5   	   -   5          �Name$  main_window��5   	    � Title$ Library Management System��5   	   $	��800��6+   $
��1215��68    � 
ResizeMode$ CanMinimize=�6E   ���	#FFFEFEE2 � Icon$ /cloud-library.png��6u   .��5	      � ���	#FFFFFFD3$
��Auto=�6"   $
��Auto=�6T    � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $	��125 �6   �� 5      .+�5   
   �� ���	#FF2C4B7D$	��125��6(   $��Center=�65   $
��Left=�6P   $	��179��6k   �� 5   
   $
��Left=�6   $	��179��6,   ._�5      ]� $��Center=�6   $��Center=�63   .+�5      ��  � ToolTip$ For Search and Find Books��6   ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � ��	 �� Value$g	 aC:\Users\Burak\Desktop\Kutuphane\Library_Management\Library_Management\images\icons\find_book.png��67   �� 5       � ��$
	 auto��67   �� 5       � ��$	 75��66   
 �� Triggers
 5      P� 5   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5   &   ��  � ��$g	 aC:\Users\Burak\Desktop\Kutuphane\Library_Management\Library_Management\images\icons\find_book.png��6?   �� 5   &    � ��$	 85��6>   5!   #   5#      5%      5&      5'      �� 5(   
   ���	#FFA2C59F$��	179,0,0,0q�6,   $	��125��6?   $��Center=�6L   �� 5)   
   $��
0,0,1026,0q�6   �� 5*   
   ���	#FFB4DCDA$��1��6(   $
��Left=�65   $	��179��6P   $	��659��6\   $��Center=�6i   �� 5+   
   �� 5,   
   -   5         ��Name$ bookListBtn��5,      $��1��6&   $��0,26,1021,553q�63   ���	#FF90C1BE$��75��6a   $	��179��6p   $��Stretch=�6   $��LeftToRight=�6�    � IsSharedSizeScope$
 True��6�    � UseLayoutRounding$
 True��6�   ��5-      �� 5.       �� Color$ 	#FF707070��6"    �� Opacity$ 0Q�64   .��50      ]� $��False��6   $��41��6.   $	��179��6:    J� RenderTransformOrigin$ 0.913,0.565&�6F   .+�51      �� $��50��6   $��/book_list.png��6#   $��30��6;   $
 True��6G   $
 True��6`   $��30��6~   $��30��6�   $��Stretch=�6�   �� 52      $��	Book List��6   $	��100��6,   
�������$��38��6K   $ 0.505,0.573&�6W   $
��Left=�6{   $
��Left=�6�   $��Center=�6�   $
 True��6�   $
 True��6�   $
��True��6  54      56      �� 57   
   -   5        $ userManagementBtninMain��57      $��1��62   $��0,106,1021,473q�6?   ���	#FF90C1BE$��75��6n   $��Stretch=�6}   $��LeftToRight=�6�   $ False��6�   $
��Left=�6�   ��58      �� 59      $ 	#FF707070��6"   $ 0Q�64   .��5;      ]� $��False��6   $��41��6.   $	��179��6:   $ 0.913,0.565&�6F   .+�5<      �� $��50��6   $m��gC:\Users\Burak\Desktop\Kutuphane\Library_Management\Library_Management\images\icons\user_management.png��6#   $��30��6�   $
 True��6�   $
 True��6�   $��30��6�   $��30��6�   $��Stretch=�6�   �� 5=      $��User Management��6   $	��124��62   
�������$��38��6Q   $ 0.505,0.573&�6]   $
��Left=�6�   $
��Left=�6�   $��Center=�6�   $ False��6�   5?      5@      �� 5A   
   -   5        $ escrowManagementBtninMain��5A      $��1��64   $��0,187,1020,392q�6A   ���	#FF90C1BE$��75��6p   $	��179��6   $��Stretch=�6�   $��LeftToRight=�6�   $
 True��6�   $
 True��6�   ��5B      �� 5C      $ 	#FF707070��6"   $ 0Q�64   .��5E      ]� $��False��6   $��41��6.   $	��179��6:   $ 0.913,0.565&�6F   .+�5F      �� $��50��6   $o��iC:\Users\Burak\Desktop\Kutuphane\Library_Management\Library_Management\images\icons\escrow_management.png��6#   $��30��6�   $
 True��6�   $
 True��6�   $��30��6�   $��30��6�   $��Stretch=�6�   �� 5G      $��Escrow Management��6   $	��127��64   
�������$��38��6S   $ 0.505,0.573&�6_   $
��Left=�6�   $
��Left=�6�   $��Center=�6�   $
 True��6�   $
 True��6�   $
��True��6  $��Normal$�69  $��Segoe UI)�6L  $��Normal"�6b  5I      5J      �� 5K   
   -   5        $ extrabtn1inmain��5K      $��1��6*   $��0,266,1021,313q�67   ���	#FF90C1BE$��75��6f   $	��179��6u   $��Stretch=�6�   $��LeftToRight=�6�   $
 True��6�   $
 True��6�   ��5L      �� 5M      $ 	#FF707070��6"   $ 0Q�64   .��5O      ]� $��False��6   $��41��6.   $	��179��6:   $ 0.913,0.565&�6F   .+�5P      �� $��50��6   $��/book_list.png��6#   $��30��6;   $
 True��6G   $
 True��6`   $��30��6~   $��30��6�   $��Stretch=�6�   �� 5Q      $��
Book List2��6   $	��124��6-   
�������$��38��6L   $ 0.505,0.573&�6X   $
��Left=�6|   $
��Left=�6�   $��Center=�6�   $
 True��6�   $
 True��6�   $
��True��6  5S      5T      �� 5U   
   -   5        $ extrabtn2inmain��5U      $��1��6*   $��0,344,1021,235q�68   ���	#FF90C1BE$��75��6g   $��Stretch=�6w   $��LeftToRight=�6�   $
 True��6�   $
 True��6�   ��5V      �� 5W      $ 	#FF707070��6"   $ 0Q�64   .��5Y      ]� $��False��6   $��41��6.   $	��179��6:   $ 0.913,0.565&�6F   .+�5Z      �� $��50��6   $��/book_list.png��6#   $��30��6;   $
 True��6G   $
 True��6`   $��30��6~   $��30��6�   $��Stretch=�6�   �� 5[      $��
Book List2��6   $	��125��6-   
�������$��38��6L   $ 0.505,0.573&�6X   $
��Left=�6|   $
��Left=�6�   $��Center=�6�   $
 True��6�   $
 True��6�   $
��True��6  5]      5^      �� 5_   
   $��	User Info��6   $��990,32,0,63q�6$   ���	#FFFFAA20$
��Left=�6P   $��85��6k   $��Right=�6y   $��30��6�   �� 5`   
   $��	User Rank��6   $��990,62,0,33q�6$   ���	#FFFF8900$
��Left=�6P   $��30��6k   $��Right=�6w   $��85��6�   �� 5a   
   $��1086,10,10,10q�6   $��/user_icon.png��6'   $	��100��6?   �� 5b   
   $��Total Number of Books: ��6   $
��Left=�62   $��
226,34,0,0q�6M   $	��Top=�6a   $	��138��6y   �� 5c   
   $��Number of Active Users:��6   $
��Left=�62   $��
226,74,0,0q�6M   $	��Top=�6a   �� 5d   
   $ ��Number of Borrowed Books: ��6   $
��Left=�65   $��
474,34,0,0q�6P   $	��Top=�6d   $	��182��6|   �� 5e   
   -   5         ��Name$ ttlLbl1��5e      $��
total_book��6!   $
��Left=�66   $��
359,34,0,0q�6Q   $	��Top=�6e   $��38��6}   �� 5f   
   -   5        $ actLbl��5f      $�� ��6    $
��Left=�6+   $��
359,74,0,0q�6F   $	��Top=�6Z   $��38��6r   �� 5g   
   -	   5        $ brwLbl��5g      $��borrowed��6    $
��Left=�63   $��
630,34,0,0q�6N   $	��Top=�6b   $��38��6z   � 5h   
   -
   5         �Name$ 
ContentGrd��5h      $��1��6#   $��	179,0,0,0q�60   .+�5i      �� -   5        $ 	Dbopening��5i      $��Label��6'   $
��Left=�67   $��-175,611,0,0q�6R   $	��Top=�6h   $	��171��6�   $��9(�6�   $��Bottom=�6�   $
��Left=�6�   5j      5o      5p      