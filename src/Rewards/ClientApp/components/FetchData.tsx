import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    forecasts: RewardModel[];
    loading: boolean;
    currentPage: number;
}

export class FetchData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { 
            forecasts: [], 
            loading: true, 
            currentPage: 1 
        };

        this.fetchData(this.state.currentPage);
    }
    
    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return <div>
            <div>
                <a href="javascript:void(0);" onClick={() => this.goToPreviousPage()}>
                    Previous page
                </a>
                <span>{this.state.currentPage}</span>
                <a href="javascript:void(0);" onClick={() => this.goToNextPage()}>
                    Next page
                </a>
            </div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>;
    }

    goToPreviousPage() {
        const previousPage = this.state.currentPage - 1;
        this.fetchData(previousPage);
    }

    goToNextPage() {
        const nextPage = this.state.currentPage + 1;        
        this.fetchData(nextPage);
    }

    fetchData(pageNumber: number) {
        fetch(`api/SampleData/Rewards?pageNumber=${pageNumber}`)
            .then(response => response.json() as Promise<RewardModel[]>)
            .then(data => {
                this.setState({ 
                    forecasts: data, 
                    loading: false,
                    currentPage: pageNumber
                 });
            });
    }

    private static renderForecastsTable(forecasts: RewardModel[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Date created</th>
                    <th>Title</th>
                    <th>Discount type</th>
                </tr>
            </thead>
            <tbody>
            {forecasts.map((forecast, i) =>
                <tr key={ i }>
                    <td>{ forecast.id }</td>
                    <td>{ forecast.dateCreatedFormatted }</td>
                    <td>{ forecast.title }</td>
                    <td>{ forecast.discountType }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface RewardModel {
    id: string,
    dateCreatedFormatted: string;
    title: string,
    discountType: string
}
