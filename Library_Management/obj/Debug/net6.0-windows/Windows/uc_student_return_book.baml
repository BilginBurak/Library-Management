   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      7    1Library_Management.Windows.uc_student_return_book   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  datagrd_booklist��5
      $	��689��6X   $
��Left=�6d   $	��Top=�6   $	��471��6�   $��	25,59,0,0q�6�      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�   $
��11.7(�6  ���	#7FC8F79B   HorizontalGridLinesBrush �	#CC41651F   VerticalGridLinesBrush �	#CC41651F6P  �� 5   
   -   5         ��Name$ 	btnborrow��5   >      Buttonround_corner#���   6   $��Return Book��6Q   $
��Left=�6g   $��868,510,0,0q�6�   $	��Top=�6�   $��40��6�   $	��107��6�   ���	#FF426FB76�   �� 5   
   -   5         ��Name$ ısbn_txtbx��5      $
��Left=�6&   $��761,263,0,0q�6A    �� TextWrapping$ NoWrap=�6V   $	��Top=�6l   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�    �� 
IsReadOnly$
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ escrowdate_txtbx��5      $
��Left=�6,   $��761,352,0,0q�6G   $ NoWrap=�6\   $	��Top=�6r   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6   �� 5   
   -   5        $ booktitle_txtbx1��5      $
��Left=�6,   $��
761,84,0,0q�6G   $ NoWrap=�6[   $	��Top=�6q   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ author_txtbx��5      $
��Left=�6(   $��761,173,0,0q�6C   $ NoWrap=�6X   $	��Top=�6n   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ duedate_txtbx��5      $
��Left=�6)   $��761,441,0,0q�6D   $ NoWrap=�6Y   $	��Top=�6o   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   $
��ISBN��6   $
��Left=�6   $��761,238,0,0q�6:   $	��Top=�6O   $	��214��6g   $��15,0,5,0q�6s   $��Center=�6�   $��25��6�   �� 5   
   $��Escrow Date��6   $
��Left=�6&   $��761,327,0,0q�6A   $	��Top=�6V   $	��214��6n   $��15,0,5,0q�6z   $��Center=�6�   $��25��6�   �� 5   
   $��
Book Title��6   $
��Left=�6%   $��
761,59,0,0q�6@   $	��Top=�6T   $	��214��6l   $��15,0,5,0q�6x   $��Center=�6�   $��25��6�   �� 5   
   $��Author��6   $
��Left=�6!   $��761,148,0,0q�6<   $	��Top=�6Q   $	��214��6i   $��15,0,5,0q�6u   $��Center=�6�   $��25��6�   �� 5   
   $��Due Date��6   $
��Left=�6#   $��761,416,0,0q�6>   $	��Top=�6S   $	��214��6k   $��15,0,5,0q�6w   $��Center=�6�   $��25��6�   �� 5   
   -	   5        	 ��Name$	 
result_lbl��5      $��Label��6$   $
��Left=�64   $��
25,530,0,0q�6O   $	��Top=�6c   $	��200��6{   $��15,5,5,5q�6�   5      5      