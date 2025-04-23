import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-google-login',
  standalone: true, // Подтверждаем standalone
  imports: [HttpClientModule], // Импортируем необходимые модули
  templateUrl: './google-login.component.html',
  styleUrls: ['./google-login.component.css']
})
export class GoogleLoginComponent implements OnInit {
  clientId = environment.googleClientId;

  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    console.log("clientId :" + this.clientId);

    // Load Google Identity Services script
    const script = document.createElement('script');
    script.src = 'https://accounts.google.com/gsi/client';
    script.async = true;
    script.defer = true;
    document.head.appendChild(script);

    // Declare callback function globally
    (window as any).handleCredentialResponse = (response: any) => {
      // Send ID token to backend
      this.http.post(`${environment.apiUrl}/api/auth/google`, { idToken: response.credential })
        .subscribe({
          next: (res: any) => {
            localStorage.setItem('jwt', res.token);
            console.log('Login successful', res);
          },
          error: (err) => console.error('Login failed', err)
        });
    };
  }
}
