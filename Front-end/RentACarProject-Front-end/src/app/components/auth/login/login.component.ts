import { Router } from '@angular/router';
import { LocalStorageService } from './../../../services/localStorage/local-storage.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../../../services/auth/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService,
    private localStorageService:LocalStorageService,
    private router:Router
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm(){
    this.loginForm = this.formBuilder.group({
      emailAdress:['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      let loginModel = Object.assign({},this.loginForm.value)

      this.authService.login(loginModel).subscribe(response=>{
        this.toastr.info(response.message);
        this.router.navigate([""]);
        this.localStorageService.add('token', response.data.token)
      },responseError=>{
        console.log(responseError)
        this.toastr.error(responseError.error.ErrorMessage)
      })
    } else {
      this.toastr.error('Formunuz eksik', 'Dikkat');
    }
  }
}
