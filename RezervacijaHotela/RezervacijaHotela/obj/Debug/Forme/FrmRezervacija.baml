   M S B A M L   `   `   `  ����L  HRezervacijaHotela, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:RezervacijaHotela.FormeRezervacijaHotela.Forme  5   	   ,    &RezervacijaHotela.Forme.FrmRezervacija   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:RezervacijaHotela.Forme     5   	     � Title$  Dodaj/Izmeni rezervaciju��5   	   $	��340��6*   $	��300��67   .��5	      � .+�5
   
   �� $��Datum rezervacije:��6   $
��Left=�6-   $��	30,20,0,0q�6H   $	��Top=�6[   �� 5   
   $��Datum prijave:��6   $
��Left=�6)   $��	30,50,0,0q�6D   $	��Top=�6W   �� 5   
   $��Datum odjave:��6   $
��Left=�6(   $��	30,80,0,0q�6C   $	��Top=�6V   �� 5   
   $��	Korisnik:��6   $
��Left=�6$   $��
30,110,0,0q�6?   $	��Top=�6S   �� 5   
   $��	Apartman:��6   $
��Left=�6$   $��
30,140,0,0q�6?   $	��Top=�6S   �� 5   
   $��Gost:��6   $
��Left=�6    $��
30,170,0,0q�6;   $	��Top=�6O   �� 5   
   $��Dodatne usluge:��6   $
��Left=�6*   $��
30,200,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��154,110,0,0q�6B   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ Korisnik��6{    �� SelectedValuePath$ 
KorisnikID��6�   �� 5   
   -   5        $ 
cbApartman��5      $
��Left=�6'   $��154,140,0,0q�6B   $	��Top=�6W   $	��120��6o   $ 
ApartmanID��6{   $ 
ApartmanID��6�   �� 5   
   -   5        $ cbGost��5      $
��Left=�6#   $��154,170,0,0q�6>   $	��Top=�6S   $	��120��6k   $
 Gost��6w   $ GostID��6�   �� 5   
   -   5        $ cbDodatneUsluge��5      $
��Left=�6,   $��154,200,0,0q�6G   $	��Top=�6\   $	��120��6t   $ OpisDodatnihUsluga��6�   $ DodatneUslugeID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
30,271,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��180,271,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   $��
Plaćanje:��6   $
��Left=�6$   $��
30,231,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ 
cbPlacanje��5      $
��Left=�6'   $��154,234,0,0q�6B   $	��Top=�6W   $	��120��6o   $ NacinPlacanja��6{   $ 
PlacanjeID��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatumRezervacije��5      $
��Left=�61   $��
154,20,0,0q�6L   $	��Top=�6`   $	��120��6x     5   
   -	   5        $ dpDatumPrijave��5      $
��Left=�6-   $��
154,51,0,0q�6H   $	��Top=�6\   $	��120��6t     5   
   -
   5        $ dpDatumOdjave��5      $
��Left=�6,   $��
154,81,0,0q�6G   $	��Top=�6[   $	��120��6s   5      5      