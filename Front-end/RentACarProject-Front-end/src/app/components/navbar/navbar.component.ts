import { LocalStorageService } from './../../services/localStorage/local-storage.service';
import { AuthService } from './../../services/auth/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isAuth:boolean=false;
  constructor(private authService:AuthService,
    private localStorageService:LocalStorageService) { }

  ngOnInit(): void {
    this.isAuth = this.authService.isAuthenticated();
  }

  exit(){
    this.isAuth = false;
    this.localStorageService.delete("token");
    window.location.reload()
  }
}
