import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.registerForm= this.fb.group({
      'username': ['', Validators.required],
      'password': ['', Validators.required],
      'password2': ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  register(){
    this.authService.register(this.registerForm.value)
  }

  get username(){
    return this.registerForm.get('username');
  }

  get password(){
    return this.registerForm.get('password');
  }

  get password2(){
    return this.registerForm.get('password2');
  }
}
