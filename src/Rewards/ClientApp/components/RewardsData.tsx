import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    forecasts: RewardModel[];
    paginationData: PaginationModel;
    loading: boolean;
    currentPage: number;
}

export class RewardsData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { 
            forecasts: [], 
            paginationData: {} as PaginationModel,
            loading: true, 
            currentPage: 1 
        };

        this.fetchData(this.state.currentPage);
    }
    
    public render() {
        const { loading, forecasts, currentPage, paginationData } = this.state;

        let contents = loading
            ? <p><em>Loading...</em></p>
            : RewardsData.renderForecastsTable(forecasts);

        const nextPageEnabled = paginationData.pageSize * currentPage < paginationData.totalRecords;
        const previousPageEnabled = currentPage > 1;
        
        return <div>
            <div>
                <a href="javascript:void(0);"
                    className={`btn${previousPageEnabled ? "" : " disabled"}`} 
                    onClick={() => this.goToPreviousPage()}>
                    Previous page
                </a>
                <span>{currentPage}</span>
                <a href="javascript:void(0);"
                    className={`btn${nextPageEnabled ? "" : " disabled"}`}
                    onClick={() => this.goToNextPage()}>
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
            .then(response => response.json() as Promise<RewardDataModel>)
            .then(data => {
                this.setState({
                    forecasts: data.rewards,
                    paginationData: data.paginationData,  
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

interface RewardDataModel {
    rewards: RewardModel[],
    paginationData: PaginationModel
}

interface RewardModel {
    id: string,
    dateCreatedFormatted: string;
    title: string,
    discountType: string
}

interface PaginationModel {
    totalRecords: number,
    pageSize: number
}
