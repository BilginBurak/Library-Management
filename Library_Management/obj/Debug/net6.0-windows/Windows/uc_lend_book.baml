   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      -    'Library_Management.Windows.uc_lend_book   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        $
��1029��5   8   $	��600��6E   .��5	      � .+�5   
   �� -   5          ��Name$  Clear��5   >      Buttonround_corner#���   6   $��Clean��6M   $
��Left=�6]   $��714,520,0,0q�6x   $	��Top=�6�   $��40��6�   $	��100��6�   ���	#FF426FB76�   �� 5   
   -   5         ��Name$ txtbx_search��5      $
��Left=�6(   $��	35,10,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��429��6�   $��30��6�   $��15,0,0,0q�6�   $��Center=�6�   ���	#7FC8F79B���	#CC41651F6  �� 5   
   -   5         ��Name$ 
lbl_textbx��5      $��Search Book��6$   $
��Left=�6:   $��	36,10,0,0q�6U   $	��Top=�6h   $	��214��6�   $��17,0,5,0q�6�   $��Center=�6�   $��30��6�   ${�False��6�    J� IsHitTestVisible$ False��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrd_book��5      $	��935��6T   $
��Left=�6`   $	��Top=�6{   $	��200��6�   $��	35,45,0,0q�6�      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�   $
��11.7(�6�   ���	#7FC8F79B   HorizontalGridLinesBrush �	#CC41651F	   VerticalGridLinesBrush	 �	#CC41651F6G    5   
   -   5        $ datagrd_user��5      $	��935��6T   $
��Left=�6`   $	��Top=�6{   $	��200��6�   $��
35,305,0,0q�6�   $ False��6�   $
 True��6�   $
��11.7(�6�   ���	#7FC8F79B �	#CC41651F	 �	#CC41651F6I  �� 5   
   -   5        $ name_surname_txtbx��5      $
��Left=�6.   $��403,520,0,0q�6I   $ NoWrap=�6^   $	��Top=�6t   $	��210��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   
 �� 
IsReadOnly$

 True��6�   $��11(�6�   $��Center=�6�   ���	#7FC8F79B���	#CC41651F64  �� 5   
   -   5        $ booktitle_txtbx1��5      $
��Left=�6,   $��
98,520,0,0q�6G   $ NoWrap=�6[   $	��Top=�6q   $	��210��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $

 True��6�   $��11(�6�   $��Center=�6�   ���	#7FC8F79B���	#CC41651F61  �� 5   
   -	   5        $ 
total_lbl2��5      $��Total...��6$   $
��Left=�67   $��690,270,0,0q�6R   $	��Top=�6g   $	��280��6   $��15,0,5,0q�6�   $��Center=�6�   $��30��6�   $��Right=�6�   �� 5   
   -
   5        $ 	total_lbl��5      $��Label��6#   $
��Left=�63   $��
690,10,0,0q�6N   $	��Top=�6b   $	��280��6z   $��30��6�   $��Center=�6�   $��15,5,5,5q�6�   $��Right=�6�   �� 5   
   -   5        $  btnEdit��5   >   #���   6   $��	Lend Book��6O   $��Right=�6c   $��
0,520,98,0q�6   $	��Top=�6�   $��40��6�   $	��100��6�   $��Center=�6�   ���	#FF426FB76�   �� 5   
   -   5         ��Name$ chckbx_contact��5      $ ��Include out of stock books��6+   $
��Left=�6P   $��
518,10,0,0q�6k   $	��Top=�6   $��30��6�   $	��172��6�   $��Center=�6�   $��1,1,1,1q�6�   $��11(�6  ���	#CC41651F���	#4CC8F79B6.  �� 5   
   -   5        $ txtbx_searchuser��5      $
��Left=�6,   $��
35,270,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��429��6�   $��30��6�   $��15,0,0,0q�6�   $��Center=�6�   ���	#7FC8F79B���	#CC41651F6  �� 5   
   -   5        $ lbl_textbx_user��5      $��Search User��6)   $
��Left=�6?   $��
36,270,0,0q�6Z   $	��Top=�6n   $	��214��6�   $��17,0,5,0q�6�   $��Center=�6�   $��30��6�   ${�False��6�   $ False��6�   �� 5   
   $��>>>>>>��6   $
��Left=�6!   $��313,526,0,0q�6<   $	��Top=�6Q   $��85��6i   $��Center=�6t   $��Center=�6�   $��28��6�   5       5!      