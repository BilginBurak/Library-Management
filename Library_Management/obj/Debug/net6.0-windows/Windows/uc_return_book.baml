   M S B A M L   `   `   `  ����M  ILibrary_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Library_Management.WindowsLibrary_Management.Windows  5      /    )Library_Management.Windows.uc_return_book   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Library_Management.Windows     5      -   5        .��5	      � .+�5   
   �� -   5          ��Name$  Clear��5   >      Buttonround_corner#���   6   $��Clean��6M   $
��Left=�6]   $��
514,25,0,0q�6x   $	��Top=�6�   $��30��6�   $	��120��6�   ���	#FF426FB76�   �� 5   
   -   5         ��Name$ txtbx_search��5      $
��Left=�6(   $��	97,25,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��400��6�   $��30��6�   $��15,0,0,0q�6�   $��Center=�6�   ���	#7FC8F79B���	#CC41651F6  �� 5   
   -   5         ��Name$ 
lbl_textbx��5      $��Search Book or User��6$   $
��Left=�6B   $��	98,25,0,0q�6]   $	��Top=�6p   $	��214��6�   $��17,0,5,0q�6�   $��Center=�6�   $��30��6�   ${�False��6�    J� IsHitTestVisible$ False��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrd_duedatebook��5      $	��950��6[   $
��Left=�6g   $	��Top=�6�   $	��407��6�   $��	25,84,0,0q�6�      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�   $
��11.7(�6
  ���	#7FC8F79B   HorizontalGridLinesBrush �	#CC41651F	   VerticalGridLinesBrush	 �	#CC41651F6V  �� 5    
   -   5        $ 	total_lbl��5       $��Label��6#   $
��Left=�63   $��
639,25,0,0q�6N   $	��Top=�6b   $	��261��6z   $��30��6�   $��Center=�6�   $��15,5,5,5q�6�   $��Right=�6�   �� 5"   
   -   5        $  btnEdit��5"   >   #���   6   $��Return��6O   $
��Left=�6`   $��793,516,0,0q�6{   $	��Top=�6�   $��40��6�   $	��107��6�   $��Center=�6�   ���	#FF426FB76�   �� 5#   
   -   5        $ name_surname_txtbx2��5#      $
��Left=�6/   $��408,516,0,0q�6J   $ NoWrap=�6_   $	��Top=�6u   $	��210��6�   $��40��6�   $��Center=�6�   $��0,0,0,0q�6�   $��11(�6�   $��Center=�6�   
 �� 
IsReadOnly$

 True��6  ���	#7FC8F79B���	#CC41651F64  �� 5%   
   -	   5        $ booktitle_txtbx2��5%      $
��Left=�6,   $��102,516,0,0q�6G   $ NoWrap=�6\   $	��Top=�6r   $	��210��6�   $��40��6�   $��Center=�6�   $��0,0,0,0q�6�   $��11(�6�   $��Center=�6�   $

 True��6  ���	#7FC8F79B���	#CC41651F61  �� 5&   
   $��<<<<<��6   $
��Left=�6/   $��317,516,0,0q�6J   $	��Top=�6_   $��35��6w   $��86��6�   $��Center=�6�   $��Center=�6�   5)      5*      