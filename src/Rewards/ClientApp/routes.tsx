import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { RewardsData } from './components/RewardsData';

export const routes = <Layout>
    <Route exact path='/' component={ RewardsData } />
</Layout>;
