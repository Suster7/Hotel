   M S B A M L   `   `   `  ����L  HRezervacijaHotela, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RezervacijaHotelaRezervacijaHotela  5   	   "    RezervacijaHotela.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RezervacijaHotela     5   	     � Title$  Hotel Rezervacija��5   	   $	��450��6#   $	��800��60   
���   �
�������.��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FF3E7F85��6   $ 1Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentralni��5      $��Center=�6.   $��Center=�6K   $
��auto��6f   $
��auto��6t      
IsReadOnly .    AlternatingRowBackground
 ��� �   CanUserAddRows .  	   SelectionMode$	 Single=�5   J   
   SelectionUnit$
 FullRow=�6a   $��14(�6y   �� 5   
   $��Center=�6   $	��Top=�62   $��50��6J   $
��auto��6V    �� Orientation$ 
Horizontal=�6c   .+�5      �� -   5         ��Name$ btnApartman��5      $��Apartman��6*   $��50��6=   $	��100��6I   ���	#FF00ACC5$��0q�6�   �� 5      -   5        $ btnDodatneUsluge��5      $��Dodatne Usluge��6/   $��50��6H   $	��100��6T   ���	#FF00ACC56   �� 5      -   5        $ btnGost��5      $
��Gost��6&   $��50��65   $	��100��6A   ���	#FF00ACC56c   �� 5      -   5        $ btnKorisnik��5      $��Korisnik��6*   $��50��6=   $	��100��6I   ���	#FF00ACC56o   �� 5      -   5        $ btnPlacanje��5      $��	Plaćanje��6*   $��50��6=   $	��100��6I   ���	#FF00ACC56o   �� 5      -   5        $ btnRezervacija��5      $��Rezervacija��6-   $��50��6C   $	��100��6O   ���	#FF00ACC56x   �� 5      -   5        $ btnStatusApartmana��5      $��Status Apartmana��61   $��50��6L   $	��100��6X   ���	#FF00ACC56�   �� 5      -	   5        $ btnTipApartmana��5      $��Tip Apartmana��6.   $��50��6F   $	��100��6R   ���	#FF00ACC56|   5      �� 5   
   $��Center=�6   $��Bottom=�62   $��50��6M   $
��auto��6Y   $ 
Horizontal=�6f   .+�5      �� -
   5        $ btnDodaj��5      $��Dodaj��6'   $��50��67   $	��100��6C   ���	#FF2C2C2C
�������$
��Bold"�6�   $��18(�6�   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $��50��69   $	��100��6E   ���	#FF2C2C2C
�������$��18(�6�   $
��Bold"�6�   �� 5      -   5        $ btnObrii��5      $��Obriši��6'   $��50��68   $	��100��6D   ���	#FF2C2C2C
�������$
��Bold"�6�   $��18(�6�   5       5!      5"      