import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-blogs',
  standalone: true,
  templateUrl: './blogs.html',
  styleUrl: './blogs.css',
  imports: [RouterModule]
})
export class Blogs {
  title = 'Blogs';
}
