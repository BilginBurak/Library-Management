   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      .    (Library_Management.Windows.uc_clear_user   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  datagrd_clearuser��5      $	��689��6Y   $
��Left=�6e   $	��Top=�6�   $	��466��6�   $��	25,84,0,0q�6�      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�   $
��11.7(�6  ���	#7FC8F79B   HorizontalGridLinesBrush �	#CC41651F   VerticalGridLinesBrush �	#CC41651F6W  �� 5   
   -   5         ��Name$ namesurname_txtbx��5      $
��Left=�6-   $��
761,84,0,0q�6H    �� TextWrapping$ NoWrap=�6\   $	��Top=�6r   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�    �� 
IsReadOnly$
 True��6�   ���	#7FC8F79B���	#CC41651F6   �� 5   
   -   5        $ username_txtbx��5      $
��Left=�6*   $��761,173,0,0q�6E   $ NoWrap=�6Z   $	��Top=�6p   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ email_txtbx��5      $
��Left=�6'   $��761,263,0,0q�6B   $ NoWrap=�6W   $	��Top=�6m   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5        $ phone_txtbx��5      $
��Left=�6'   $��761,352,0,0q�6B   $ NoWrap=�6W   $	��Top=�6m   $	��214��6�   $��40��6�   $��Center=�6�   $��15,0,0,0q�6�   $
 True��6�   ���	#7FC8F79B���	#CC41651F6�   �� 5   
   -   5         ��Name$ btnclearuser��5   ?      Buttonround_corner#���   6   $��Delete User��6U   $
��Left=�6k   $��868,510,0,0q�6�   $	��Top=�6�   $��40��6�   $	��107��6�   ���	#FF426FB76�   �� 5   
   $��Name Surname��6   $
��Left=�6'   $��
761,59,0,0q�6B   $	��Top=�6V   $	��214��6n   $��15,0,5,0q�6z   $��Center=�6�   $��25��6�   �� 5   
   $��Username��6   $
��Left=�6#   $��761,148,0,0q�6>   $	��Top=�6S   $	��214��6k   $��15,0,5,0q�6w   $��Center=�6�   $��25��6�   �� 5   
   $��E-mail��6   $
��Left=�6!   $��761,238,0,0q�6<   $	��Top=�6Q   $	��214��6i   $��15,0,5,0q�6u   $��Center=�6�   $��25��6�   �� 5   
   $��Phone��6   $
��Left=�6    $��761,327,0,0q�6;   $	��Top=�6P   $	��214��6h   $��15,0,5,0q�6t   $��Center=�6�   $��25��6�   �� 5   
   -   5        $ txtbx_search��5      $
��Left=�6(   $��	25,25,0,0q�6C   $
 Wrap=�6V   $	��Top=�6j   $	��508��6�   $��30��6�   $��15,0,0,0q�6�   $��Center=�6�   ���	#7FC8F79B���	#CC41651F6  �� 5   
   -	   5        $ Clean��5   >   #���   6   $��Clean��6M   $
��Left=�6]   $��
594,25,0,0q�6x   $	��Top=�6�   $��30��6�   $	��120��6�   ���	#FF426FB76�   �� 5   
   $��
User Level��6   $
��Left=�6%   $��761,416,0,0q�6@   $	��Top=�6U   $	��214��6m   $��15,0,5,0q�6y   $��Center=�6�   $��25��6�   �� 5   
   -
   5        	 ��Name$	 cmbbx_userrank��5      $
��Left=�6+   $��761,441,0,0q�6F   $	��Top=�6[   $	��214��6s   $��40��6   $��15,3,5,3q�6�   $��Center=�6�   
 �� 
IsReadOnly$

 True��6�    J� IsHitTestVisible$ False��6�   ���	#7FC8F79B���	#CC41651F6  �� 5   
   -   5         ��Name$ 
lbl_textbx��5      $��Search for Anything��6$   $
��Left=�6B   $��	26,25,0,0q�6]   $	��Top=�6p   $	��214��6�   $��17,0,5,0q�6�   $��Center=�6�   $��30��6�   ${�False��6�   $ False��6�   �� 5   
   -   5        $ 
result_lbl��5      $��Label��6$   $
��Left=�64   $��
25,550,0,0q�6O   $	��Top=�6c   $	��231��6{   $��15,5,5,5q�6�   $��Center=�6�   5      5      