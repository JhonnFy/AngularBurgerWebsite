import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-reviews',
  standalone: true,
  templateUrl: './reviews.html',
  styleUrl: './reviews.css',
  imports: [RouterModule]
})
export class Reviews {
  title = 'Reviews';
}
