   M S B A M L   `   `   `  ����L  HRezervacijaHotela, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:RezervacijaHotela.FormeRezervacijaHotela.Forme  5   	   )    #RezervacijaHotela.Forme.FrmApartman   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:RezervacijaHotela.Forme     5   	     � Title$  Dodaj/Izmeni apartman��5   	   $��209.067��6'   $	��300��68   .��5	      � $��0,0,-0.4,-0.6q�6   .+�5
   
   �� $��
Broj soba:��6   $
��Left=�6%   $��	30,23,0,0q�6@   $	��Top=�6S   �� 5   
   -   5         ��Name$ txtBrojSoba��5      $
��Left=�6'   $��
147,23,0,0q�6B   $�� ��6V   $��23��6^    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,140,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��192,140,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   $��Tip Apartmana:��6   $
��Left=�6)   $��	30,51,0,0q�6D   $	��Top=�6W   �� 5   
   $��Status Apartmana:��6   $
��Left=�6,   $��	30,82,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5         ��Name$ cbTipApartmana��5      $
��Left=�6+   $��
147,54,0,0q�6F   $	��Top=�6Z   $	��120��6r    �� DisplayMemberPath$ NazivTipaApartmana��6~    �� SelectedValuePath$ TipApartmanaID��6�   �� 5   
   -   5        $ cbStatusApartmana��5      $
��Left=�6.   $��
147,85,0,0q�6I   $	��Top=�6]   $	��120��6u   $ Status��6�   $ StatusApartmanaID��6�   5      5      