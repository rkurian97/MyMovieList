import { Component, OnInit } from '@angular/core';
import { RootObject } from '../_models/Rootobject';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  popularMovies?: RootObject;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getPopularMovies();
  }

  getPopularMovies(){
    var httpRequest= this.http.get<RootObject>("https://localhost:7020/home/getpopularmovies")

    httpRequest.subscribe(returnedObject =>{
      this.popularMovies= returnedObject;
      console.log(returnedObject)
      console.log(this.popularMovies.results[0].backdrop_path)
    })
    
    
  }

}
