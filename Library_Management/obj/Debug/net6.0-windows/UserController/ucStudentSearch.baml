   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Library_Management.UserController!Library_Management.UserController  5      7    1Library_Management.UserController.ucStudentSearch   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Library_Management.UserController     5      -   5        $	��800��5   8   $
��1200��6E   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  booklistdtgrd��5      $��	0,60,0,60q�6U      CanUserAddRows$ False��6h   ���	#7FC8F79B   HorizontalGridLinesBrush �	#CC41651F   VerticalGridLinesBrush �	#CC41651F6�   �� 5   
   -   5           Buttonround_corner#���   5      $��Clear��6>   $
��Left=�6N   $��
970,10,0,0q�6i   $	��Top=�6}   $��38��6�   $	��177��6�   $��16(�6�   ���	#FF006DFF6�   �� 5   
   -   5         ��Name$ txtbxforsearch��5   3   $
��Left=�6K   $��
400,10,0,0q�6f    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��522��6�   $��38��6�   $��Center=�6�   $��15,0,0,0q�6	  ���	#7FC8F79B���	#CC41651F63  �� 5   
   -   5         ��Name$ cmbbxforsearchscreen��5      $
��Left=�61   $��
174,10,0,0q�6L   $	��Top=�6`   $	��180��6x   $��38��6�    K� ZIndex$ 12��6�   $��Center=�6�    �� Text$ Select Category��6�   4  .System.Windows.Automation.AutomationProperties	   HelpText$	 asdasdas��6�   $��15,3,5,3q�6  �� 5   
   -   5        
 ��Name$
 lblinsearchbox��5      $��Text for Search��6(   $
��Left=�6B   $��
400,16,0,0q�6]   $	��Top=�6q   $	��178��6�   ${�False��6�   $��17,5,5,5q�6�    J� IsHitTestVisible$ False��6�   ��6�   Z� 6�   �� 5   
   -   5         ��Name$ previouspagebtn��5   /   $��473,759,699,14q�6H   ���	#FF718C88$��16(�6w   ��5      �� 5       �� 
TargetType" ��6"   .R�5      � .+�5      A� ���	#FF006DFF6"   �� 5      $��Center=�6+   $��Center=�6H   5      5       5"      �� 5#   
   -   5        $ nextpagebtn��5#   +   $��647,759,525,14q�6@   ���	#FF718C88$��16(�6o   ��5$      �� 5%      " ��6"   .R�5&      � .+�5'      A� ���	#FF006DFF6"   �� 5(      $��Center=�6+   $��Center=�6H   5)      5*      5,      �� 5-   
   -	   5        $
 totalpagelbl��5-      $��1��6&   $
��Left=�62   $��604,757,0,0q�6M   $	��Top=�6b   $��16(�6z   $��Center=�6�   �� 5.   
   $��/��6   $
��Left=�6   $��596,757,0,0q�67   $	��Top=�6L   $��16(�6d   $��Center=�6r   $��Center=�6�   �� 5/   
   -
   5        $ cmbbxforskippage��5/   <   $
��Left=�6V   $��533,759,0,0q�6q   $	��Top=�6�   $��64��6�   $��Center=�6�   $��16(�6�   $��10,3,4,3q�6�    �� 
IsEditable$
 True��6�    �� SelectedIndex$ 0��6�   �� 50   
   $��>��6   $
��Left=�6   $��647,759,0,0q�6:   $	��Top=�6O   $��27��6g   $��28��6s   $��Center=�6~   $��Center=�6�   $��Arial Black)�6�   ${�False��6�   $ False��6�   
���   �6  �� 51   
   $��<��6   $
��Left=�6   $��473,759,0,0q�6:   $	��Top=�6O   $��27��6g   $��28��6s   $��Center=�6~   $��Center=�6�   $��Arial Black)�6�   ${�False��6�   
���   �$ False��6  �� 52   
   -   5        $ firstpagebtn��52   ,   $��434,759,738,14q�6B   ���	#FF718C88$��16(�6q   ��53      �� 54      " ��6"   .R�55      � .+�56      A� ���	#FF006DFF6"   �� 57      $��Center=�6+   $��Center=�6H   58      59      5;      �� 5<   
   $��<<��6   $
��Left=�6#   $��434,759,0,0q�6>   $	��Top=�6S   $��27��6k   $��28��6w   $��Center=�6�   $��Center=�6�   $��Arial Black)�6�   ${�False��6�   
���   �$ False��6  �� 5=   
   -   5        $ lastpagebtn��5=   +   $��686,759,486,14q�6@   ���	#FF718C88$��16(�6o   ��5>      �� 5?      " ��6"   .R�5@      � .+�5A      A� ���	#FF006DFF6"   �� 5B      $��Center=�6+   $��Center=�6H   5C      5D      5F      �� 5G   
   $��>>��6   $
��Left=�6#   $��686,759,0,0q�6>   $	��Top=�6S   $��27��6k   $��28��6w   $��Center=�6�   $��Center=�6�   $��Arial Black)�6�   ${�False��6�   
���   �$ False��6  �� 5H   
   $��Number of Items Shown:��6   $
��Left=�61   $��942,760,0,0q�6L   $	��Top=�6a   $	��142��6y   �� 5I   
   -   5        $ cmbbxshowitemselector��5I   M   $
��Left=�6l   $��1089,760,0,0q�6�   $	��Top=�6�   $��81��6�   $��29��6�   $��Center=�6�   $��17,3,5,3q�6�   .@�5J      �� $��25��6   �� 5K      $��50��6   �� 5L      $��75��6   �� 5M      $	��100��6   �� 5N      $	��200��6   5O      �� 5P   
   -   5        $
 	lblsearch��5P      $��Search in :��6#   $
��Left=�69   $��	26,10,0,0q�6T   $	��Top=�6g   $	��143��6   $��38��6�   $��Center=�6�   �� 5Q   
   -   5         ��Name$ chckbx_notbook��5Q      $"��show also books that are not��6+   $
��Left=�6R   $��240,767,0,0q�6m   $	��Top=�6�   $y�Hidden=�6�   ���	#7FC8F79B���	#CC41651F6�   �� 5R   
   -   5        $
 	total_lbl��5R      $��Label��6#   $
��Left=�63   $��736,757,0,0q�6N   $	��Top=�6c   $	��306��6{   $��30��6�   $��Center=�6�   $��15,5,5,5q�6�   5T      5U      