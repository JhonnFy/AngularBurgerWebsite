import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css'],
  imports: [RouterModule]   // ← AQUÍ EL ARREGLO
})
export class Dashboard {
  title = 'Dashboard';
}
