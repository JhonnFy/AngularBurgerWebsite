import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-contact',
  standalone: true,
  templateUrl: './contact.html',
  styleUrl: './contact.css',
  imports: [RouterModule]
})
export class Contact {
  title = 'Contact';
}
