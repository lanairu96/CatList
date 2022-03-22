import { Component, OnInit } from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import { ApiService } from 'src/app/Services/Api/api.service';


@Component({
	selector: 'app-cat-list',
	templateUrl: './cat-list.component.html',
	styleUrls: ['./cat-list.component.css']
})
export class CatListComponent implements OnInit {

	constructor(private apiService:ApiService) { }

	public data: any;

	ngOnInit(): void {
		var e = this.apiService.getCat().subscribe(
			data => {
				this.data = data;
				console.log(this.data);
			}
		);
	}

	onCatRowClick(cat: any): void {
		console.log(cat);
	}
	
}
