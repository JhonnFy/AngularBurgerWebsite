import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  templateUrl: './menu.html',
  styleUrl: './menu.css',
  imports: [RouterModule]
})
export class Menu {
  title = 'Menu';
}


