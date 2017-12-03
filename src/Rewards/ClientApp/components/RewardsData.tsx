import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface RewardsDataState {
    rewards: RewardModel[];
    paginationData: PaginationModel;
    loading: boolean;
    currentPage: number;
}

export class RewardsData extends React.Component<RouteComponentProps<{}>, RewardsDataState> {
    constructor() {
        super();
        this.state = { 
            rewards: [], 
            paginationData: {} as PaginationModel,
            loading: true, 
            currentPage: 1 
        };

        this.fetchData(this.state.currentPage, true);
    }
    
    public render() {
        const { loading, rewards, currentPage, paginationData } = this.state;

        let contents = loading
            ? <p><em>Loading...</em></p>
            : RewardsData.renderRewardsTable(rewards);

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
            <h1>Rewards list</h1>
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

    fetchData(pageNumber: number, initialLoad: boolean = false) {
        if (!initialLoad) {
            this.setState({ loading: true });
        }

        fetch(`api/RewardsData/Rewards?pageNumber=${pageNumber}`)
            .then(response => response.json() as Promise<RewardDataModel>)
            .then(data => {
                this.setState({
                    rewards: data.rewards,
                    paginationData: data.paginationData,  
                    loading: false,
                    currentPage: pageNumber
                 });
            });
    }

    private static renderRewardsTable(rewards: RewardModel[]) {
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
            {rewards.map((reward, i) =>
                <tr key={ i }>
                    <td>{ reward.id }</td>
                    <td>{ reward.dateCreatedFormatted }</td>
                    <td>{ reward.title }</td>
                    <td>{ reward.discountType }</td>
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
